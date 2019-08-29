using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.Files
{
    public class BinaryFileWrapper
    {
        public BinaryFile BinaryFile { get; set; }

        public HttpPostedFileBase PostedFile { get; set; }
    }
}