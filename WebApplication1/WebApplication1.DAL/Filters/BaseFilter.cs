using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DAL.Filters
{
    public abstract class BaseFilter
    {
        public long? Id { get; set; }

        public string SearchString { get; set; }
    }
}
