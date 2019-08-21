using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface IHttpRemoteService
    {
        object Post(string url, object @params);
    }
}
