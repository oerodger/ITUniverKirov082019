using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DAL.Filters
{
    public class FetchOptions
    {
        public string SortExpression { get; set; }

        public SortDirection SortDirection { get; set; }

        public int? First { get; set; }

        public int? Count { get; set; }
    }

    public enum SortDirection
    {
        Asc,
        Desc
    }
}
