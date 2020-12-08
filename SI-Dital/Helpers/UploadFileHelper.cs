using MessagingToolkit.QRCode.Codec;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace SI_Dital.Helpers
{
    public static class UploadFileHelper
    {
        public static byte[] ReadFileContents(HttpPostedFileBase file)
        {
            Stream fileStream = file.InputStream;
            var mStreamer = new MemoryStream();
            mStreamer.SetLength(fileStream.Length);
            fileStream.Read(mStreamer.GetBuffer(), 0, (int)fileStream.Length);
            mStreamer.Seek(0, SeekOrigin.Begin);
            byte[] fileBytes = mStreamer.GetBuffer();
            return fileBytes;
        }
        public static string ValidateFileName(string _fileName)
        {
            return Path.GetFileNameWithoutExtension(_fileName).Replace(" ", "-").ToLower();
        }
        public static string ToCustomDomain(string fileUrl)
        {
            var customDomain = ConfigurationManager.AppSettings["StorageCustomDomain"];
            var actualBlob = ConfigurationManager.AppSettings["StorageUrl"];

            if (customDomain != null && actualBlob != null)
            {
                return fileUrl.Replace(actualBlob, customDomain);
            }
            return fileUrl;
        }
        
        public static async Task<string> UploadAvatarImageAsync(byte[] buffer, string fileName, string contentType)
        {
            var permalink = "avatar";
            if (buffer.Length <= 0)
            {
                return null;
            }

            string fullPath = null;
            string fName = ValidateFileName(fileName);
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("images");

                fileName = String.Format("{0}{1}", permalink + "/" + Guid.NewGuid().ToString() + "/" + fName.Replace(" ", "-").ToLower(),
                    Path.GetExtension(fileName).ToLower());

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.Properties.ContentType = contentType;
                //await blockBlob.UploadFromStreamAsync(buffer);
                await blockBlob.UploadFromByteArrayAsync(buffer, 0, buffer.Length);

                var uriBuilder = new UriBuilder(blockBlob.Uri);
                uriBuilder.Scheme = "https";
                fullPath = uriBuilder.ToString().Replace(":443", "").ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Trace.TraceError(ex.StackTrace);
                return "";
            }
            return ToCustomDomain(fullPath);
        }
        public static async Task<string> UploadAvatarImageBase64Async(string base64string, string username, string type)
        {
            var permalink = "avatar";
            if (base64string.Length <= 0)
            {
                return null;
            }
            string fullPath = null;
            var bytes = Convert.FromBase64String(base64string);
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("images");
                var fileName = permalink + "/"+ username + "/"+ Guid.NewGuid().ToString() + "." + type;
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                using (var stream = new MemoryStream(bytes))
                {
                    await blockBlob.UploadFromStreamAsync(stream);
                }
                var uriBuilder = new UriBuilder(blockBlob.Uri);
                uriBuilder.Scheme = "https";
                fullPath = uriBuilder.ToString().Replace(":443", "").ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Trace.TraceError(ex.StackTrace);
                return "";
            }
            return ToCustomDomain(fullPath);
        }
        public static async Task<string> UploadProofImageAsync(byte[] buffer, string fileName, string contentType)
        {
            var permalink = "UploadProof";
            if (buffer.Length <= 0)
            {
                return null;
            }

            string fullPath = null;
            string fName = ValidateFileName(fileName);
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("images");

                fileName = String.Format("{0}{1}", permalink + "/" + Guid.NewGuid().ToString() + "/" + fName.Replace(" ", "-").ToLower(),
                    Path.GetExtension(fileName).ToLower());

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.Properties.ContentType = contentType;
                //await blockBlob.UploadFromStreamAsync(buffer);
                await blockBlob.UploadFromByteArrayAsync(buffer, 0, buffer.Length);

                var uriBuilder = new UriBuilder(blockBlob.Uri);
                uriBuilder.Scheme = "https";
                fullPath = uriBuilder.ToString().Replace(":443", "").ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Trace.TraceError(ex.StackTrace);
                return "";
            }
            return ToCustomDomain(fullPath);
        }

        public static async Task<string> UploadDocumentsAsync(HttpPostedFileBase fileToUpload, string tenantId)
        {
            var permalink = "documents";
            if (fileToUpload == null || fileToUpload.ContentLength == 0)
            {
                return null;
            }

            string fullPath = null;
            string fName = ValidateFileName(fileToUpload.FileName);
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("files");

                string fileName = String.Format("{0}{1}", permalink + "/" + tenantId + "/" + fName.Replace(" ", "-").ToLower(),
                    Path.GetExtension(fileToUpload.FileName).ToLower());

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.Properties.ContentType = fileToUpload.ContentType;
                await blockBlob.UploadFromStreamAsync(fileToUpload.InputStream);


                var uriBuilder = new UriBuilder(blockBlob.Uri);
                uriBuilder.Scheme = "https";
                fullPath = uriBuilder.ToString().Replace(":443", "").ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Trace.TraceError(ex.StackTrace);
                return "";
            }
            return ToCustomDomain(fullPath);
        }
        public static async Task<string> UploadAvatarImageAsync(HttpPostedFileBase fileToUpload)
            {
                var permalink = "avatar";
                if (fileToUpload == null || fileToUpload.ContentLength == 0)
                {
                    return null;
                }

                string fullPath = null;
                string fName = ValidateFileName(fileToUpload.FileName);
                try
                {
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference("images");

                    string fileName = String.Format("{0}{1}", permalink + "/" + Guid.NewGuid().ToString() + "/" + fName.Replace(" ", "-").ToLower(),
                        Path.GetExtension(fileToUpload.FileName).ToLower());

                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                    blockBlob.Properties.ContentType = fileToUpload.ContentType;
                    await blockBlob.UploadFromStreamAsync(fileToUpload.InputStream);


                    var uriBuilder = new UriBuilder(blockBlob.Uri);
                    uriBuilder.Scheme = "https";
                    fullPath = uriBuilder.ToString().Replace(":443", "").ToLower();
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    Trace.TraceError(ex.StackTrace);
                    return "";
                }
                return ToCustomDomain(fullPath);
            }
        public static async Task<string> UploadCitizenImageAsync(HttpPostedFileBase fileToUpload, string id, bool isAvatar)
        {
            var permalink = "citizen/" + id;
            if (isAvatar)
            {
                permalink = "citizen/profie/" + id;
            }

            if (fileToUpload == null || fileToUpload.ContentLength == 0)
            {
                return null;
            }

            string fullPath = null;
            string fName = ValidateFileName(fileToUpload.FileName);
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("images");

                string fileName = String.Format("{0}{1}", permalink + "/" + fName.Replace(" ", "-").ToLower(),
                    Path.GetExtension(fileToUpload.FileName).ToLower());

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.Properties.ContentType = fileToUpload.ContentType;
                await blockBlob.UploadFromStreamAsync(fileToUpload.InputStream);


                var uriBuilder = new UriBuilder(blockBlob.Uri);
                uriBuilder.Scheme = "https";
                fullPath = uriBuilder.ToString().Replace(":443", "").ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Trace.TraceError(ex.StackTrace);
                return "";
            }
            return ToCustomDomain(fullPath);
        }
        public static async Task<string> UploadLogoPlatformAsync(HttpPostedFileBase fileToUpload, string id)
        {
            var permalink = "logoplatform/" + id;

            if (fileToUpload == null || fileToUpload.ContentLength == 0)
            {
                return null;
            }

            string fullPath = null;
            string fName = ValidateFileName(fileToUpload.FileName);
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("images");

                string fileName = String.Format("{0}{1}", permalink + "/" + fName.Replace(" ", "-").ToLower(),
                    Path.GetExtension(fileToUpload.FileName).ToLower());

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.Properties.ContentType = fileToUpload.ContentType;
                await blockBlob.UploadFromStreamAsync(fileToUpload.InputStream);


                var uriBuilder = new UriBuilder(blockBlob.Uri);
                uriBuilder.Scheme = "https";
                fullPath = uriBuilder.ToString().Replace(":443", "").ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Trace.TraceError(ex.StackTrace);
                return "";
            }
            return ToCustomDomain(fullPath);
        }
        public static async Task<string> UploadFileAsync(HttpPostedFileBase fileToUpload, string tenantId)
        {
            var permalink = "document";
            if (fileToUpload == null || fileToUpload.ContentLength == 0)
            {
                return null;
            }

            string fullPath = null;
            string fName = ValidateFileName(fileToUpload.FileName);
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("files");

                string fileName = String.Format("{0}{1}", permalink + "/" + tenantId + "/" + fName.Replace(" ", "-").ToLower(),
                    Path.GetExtension(fileToUpload.FileName).ToLower());

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.Properties.ContentType = fileToUpload.ContentType;
                await blockBlob.UploadFromStreamAsync(fileToUpload.InputStream);


                var uriBuilder = new UriBuilder(blockBlob.Uri);
                uriBuilder.Scheme = "https";
                fullPath = uriBuilder.ToString().Replace(":443", "").ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Trace.TraceError(ex.StackTrace);
                return "";
            }
            return ToCustomDomain(fullPath);
        }
        public static async Task<string> UploadImage(HttpPostedFileBase fileToUpload, string id)
        {
           var permalink = "image/documentation/" + id;
            

            if (fileToUpload == null || fileToUpload.ContentLength == 0)
            {
                return null;
            }

            string fullPath = null;
            string fName = ValidateFileName(fileToUpload.FileName);
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("images");

                string fileName = String.Format("{0}{1}", permalink + "/" + fName.Replace(" ", "-").ToLower(),
                    Path.GetExtension(fileToUpload.FileName).ToLower());

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.Properties.ContentType = fileToUpload.ContentType;
                await blockBlob.UploadFromStreamAsync(fileToUpload.InputStream);


                var uriBuilder = new UriBuilder(blockBlob.Uri);
                uriBuilder.Scheme = "https";
                fullPath = uriBuilder.ToString().Replace(":443", "").ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Trace.TraceError(ex.StackTrace);
                return "";
            }
            return ToCustomDomain(fullPath);
        }
        public static async Task<string> UploadProofImageAsync(HttpPostedFileBase fileToUpload)
        {
            var permalink = "proof-of-event";
            if (fileToUpload == null || fileToUpload.ContentLength == 0)
            {
                return null;
            }

            string fullPath = null;
            string fName = ValidateFileName(fileToUpload.FileName);
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);

                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("images");

                string fileName = String.Format("{0}{1}", permalink + "/" + fName.Replace(" ", "-").ToLower(),
                    Path.GetExtension(fileToUpload.FileName).ToLower());

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.Properties.ContentType = fileToUpload.ContentType;
                await blockBlob.UploadFromStreamAsync(fileToUpload.InputStream);


                var uriBuilder = new UriBuilder(blockBlob.Uri);
                uriBuilder.Scheme = "https";
                fullPath = uriBuilder.ToString().Replace(":443", "").ToLower();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                Trace.TraceError(ex.StackTrace);
                return "";
            }
            return ToCustomDomain(fullPath);
        }
    }
}