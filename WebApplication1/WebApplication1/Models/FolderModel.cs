using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.Models
{
    public class FolderModel: EntityListModel<Folder>
    {
        public Folder Parent { get; set; }

        public Folder CurrentFolder { get; set; }

        public bool IsRootFolder { get; set; }
    }
}