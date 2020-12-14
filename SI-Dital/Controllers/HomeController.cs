using iTextSharp.text;
using iTextSharp.text.pdf;
using SI_Dital.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SI_Dital.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var documentTypes = await db.DocumentTypes.Where(x => x.IsDeleted != true).ToListAsync();
            return View(documentTypes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public async Task<ActionResult> Profile()
        {
            var currentUser = User.Identity.Name;
            var citizen = await db.Citizens.Include("RT").Include("RW").Include("Job").Where(x => x.Email == currentUser || x.NIK == currentUser).SingleOrDefaultAsync();
            if(citizen == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(citizen);
        }
        public async Task<ActionResult> History()
        {
            var currentUser = User.Identity.Name;
            var documents = await db.Documents.Include("DocumentGroup").Where(x => x.CreatedBy.UserName == currentUser).ToListAsync();
            if (documents == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var mydocuments = new ViewModels.MyDocuments
                {
                    Documents = documents,
                };
                return PartialView("_MyDocumentPartial", mydocuments);
            }
            return View("Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendRequestDocument(string Description, string DocumentType)
        {
            if(Description == null && DocumentType == null)
            {
                return Json("NULL", JsonRequestBehavior.AllowGet);
            }
            else if (ModelState.IsValid)
            {
                var currentUser = await db.Users.Where(x => x.UserName == User.Identity.Name)
                    .SingleOrDefaultAsync();
                if (currentUser != null)
                {
                    var documentType = await db.DocumentTypes.Where(x => x.Permalink == DocumentType).SingleOrDefaultAsync();
                    var addRequestDocument = new Models.Document
                    {
                        IdDocument = Guid.NewGuid().ToString(),
                        Descriptions = Description,
                        CreatedBy = currentUser,
                        Created = DateTimeOffset.UtcNow,
                        Status = Models.Status.Pending,
                        DocumentGroup = documentType,
                        IsDeleted = false
                    };
                    try
                    {
                        db.Documents.Add(addRequestDocument);
                        var result = await db.SaveChangesAsync();
                        if (result > 0)
                        {
                            return Json("OK", JsonRequestBehavior.AllowGet);
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.Message);
                        Trace.TraceError(ex.StackTrace);
                    }
                }
                else
                {
                    return Json("NOTLOGIN", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("KO", JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> PreviewDocumentToDownload(string IdDocument, string IdCitizen)
        {
            var documents = await db.Documents.Include("DocumentGroup").Where(x => x.IdDocument == IdDocument).SingleOrDefaultAsync();
            var citizen = await db.Citizens.Include("Documents").Where(x => x.Id == IdCitizen).SingleOrDefaultAsync();
            var documentCount = await db.Documents.Include("DocumentGroup").Where(x => x.Status == Models.Status.Approved).ToListAsync();
            var documentGroup = await db.DocumentTypes.Include("FileDocuments").Where(x => x.Permalink == documents.DocumentGroup.Permalink).SingleOrDefaultAsync();
            var fileDocument = await db.FileDocuments.Where(x => x.IdFileDocument == documentGroup.FileDocuments.IdFileDocument).SingleOrDefaultAsync();
            if (fileDocument != null)
            {
                var documentsCount = documentCount.Count().ToString();
                PrintCertificate(fileDocument.Name, documentsCount, fileDocument, citizen);
            }
            return null;
        }
        public void PrintCertificate(string name, string qrUrl, Models.FileDocuments certificate, Models.Citizens trackParticipant)
        {
            PdfReader reader = new PdfReader(new RandomAccessFileOrArray(certificate.File), null);
            Rectangle size = reader.GetPageSizeWithRotation(1);
            Document document = new Document(size);
            using (MemoryStream ms = new MemoryStream())
            using (PdfWriter writer = PdfWriter.GetInstance(document, ms))
            {
                try
                {
                    document.Open();
                    PdfContentByte cb = writer.DirectContentUnder;
                    BaseFont bfb = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
                    BaseFont bfr = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

                    //Open the document 

                    PdfImportedPage page = writer.GetImportedPage(reader, 1);
                    cb.AddTemplate(page, 0, 0);

                    cb.SetCharacterSpacing(0.5f);

                    //cb.SetRGBColorFill(230, 20, 30);
                    cb.SetRGBColorFill(0, 0, 0);
                    cb.BeginText();
                    cb.SetFontAndSize(bfb, Convert.ToSingle(certificate.FontSize));
                    var x = (size.Width + Convert.ToSingle(certificate.NameXPosition)) / 2;
                    var y = (size.Height + Convert.ToSingle(certificate.NameYPosition)) / 2;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, trackParticipant.FullName, x, y, 0);
                    cb.EndText();

                    //Peserta
                    //cb.SetRGBColorFill(0, 0, 0);
                    //cb.BeginText();
                    //cb.SetFontAndSize(bfb, Convert.ToSingle(26));
                    //x = (size.Width + Convert.ToSingle(certificate.NameXPosition)) / 2;
                    //y = (size.Height + Convert.ToSingle(certificate.NameYPosition - 135)) / 2;
                    //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "PESERTA", x, y, 0);
                    //cb.EndText();

                    //Judul Acara
                    //cb.SetRGBColorFill(64, 64, 64);
                    //cb.BeginText();
                    //cb.SetFontAndSize(bfr, Convert.ToSingle(25));
                    //x = (size.Width + Convert.ToSingle(certificate.NameXPosition)) / 2;
                    //y = (size.Height + Convert.ToSingle(certificate.NameYPosition - 260)) / 2;
                    //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, trackParticipant.Track.Title, x, y, 0);
                    //cb.EndText();

                    //Waktu Acara
                    //cb.SetRGBColorFill(80, 80, 80);
                    //cb.BeginText();
                    //cb.SetFontAndSize(bfr, Convert.ToSingle(16));
                    //x = (size.Width + Convert.ToSingle(certificate.NameXPosition)) / 2;
                    //y = (size.Height + Convert.ToSingle(certificate.NameYPosition - 320)) / 2;
                    //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, trackParticipant.Track.Start.ToString("dddd dd MMMM yyyy", CultureInfo.CreateSpecificCulture("id-ID")) + " di "+ trackParticipant.Track.Location.Name, x, y, 0);
                    //cb.EndText();

                    //background
                    cb.SetColorStroke(new CMYKColor(1f, 0f, 0f, 0f));
                    cb.SetColorFill(new CMYKColor(0f, 0f, 0f, 0f));
                    x = Convert.ToSingle(certificate.QRXPosition);
                    y = Convert.ToSingle(certificate.QRYPosition);
                    var qrSize = 80;
                    cb.MoveTo(x, y);
                    cb.LineTo(x + qrSize, y);
                    cb.LineTo(x + qrSize, y + qrSize);
                    cb.LineTo(x, y + qrSize);
                    cb.Fill();

                    BarcodeQRCode qrCode = new BarcodeQRCode(qrUrl, 1000, 1000, null);
                    Image image = qrCode.GetImage();
                    image.SetAbsolutePosition(x, y);
                    image.ScaleAbsolute(qrSize, qrSize);
                    document.Add(image);

                    document.Close();
                    writer.Close();
                    ms.Close();
                    var fileName = "Dokumen SI-Dital - " + qrUrl.ToUpper();
                    HttpContext.Response.ContentType = "pdf/application";
                    HttpContext.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".pdf");
                    HttpContext.Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.TraceError(ex.Message);
                }

            }
        }
    }
}