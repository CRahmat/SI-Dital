using SI_Dital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SI_Dital.ViewModels
{
    public class MyDocuments
    {
        public string DocumentTitle { set; get; }
        public ICollection<Document> Documents { get; set; }

    }
}