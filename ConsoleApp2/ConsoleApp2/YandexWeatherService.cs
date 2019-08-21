using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class YandexWeatherService : IWeatherService
    {
        public IHttpRemoteService RemoteService { get; set; }
        
        public YandexWeatherService()
        {
            
        } 
        public object Get(string city)
        {
            return RemoteService.Post("ya.ru", new { city = city });
        }
    }
}
