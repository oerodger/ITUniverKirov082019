using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    [Service]
    public class GoogleWeatherService : IWeatherService
    {
        private IHttpRemoteService remoteService;
        public GoogleWeatherService(IHttpRemoteService remoteService)
        {
            this.remoteService = remoteService;
        } 

        public object Get(string city)
        {
            return remoteService.Post("google.com", new { city = city });
        }
    }
}
