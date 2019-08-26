using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.Models
{
    public class FolderEditModel: EntityModel<Folder>
    {
        [Required]
        [DisplayName("Название папки")]
        public string Name { get; set; }

        public long? ParentId { get; set; }
    }
}