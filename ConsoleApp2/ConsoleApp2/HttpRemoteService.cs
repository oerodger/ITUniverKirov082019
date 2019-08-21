using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class HttpRemoteService : IHttpRemoteService
    {
        public object Post(string url, object @params)
        {
            return new { url = url, form = @params };
        }
    }
}
