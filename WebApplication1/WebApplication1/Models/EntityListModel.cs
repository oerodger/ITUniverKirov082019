using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EntityListModel<T>
    {
        public IList<T> Items { get; set; }
    }
}