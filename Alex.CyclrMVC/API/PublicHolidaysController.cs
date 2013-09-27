using Alex.CyclrMVC.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Alex.CyclrMVC.Controllers
{
    public class PublicHolidaysController : ApiController
    {
        public IEnumerable<PublicHoliday> Get()
        {
            var json = "";
            using (var webClient = new System.Net.WebClient())
            {
                webClient.Proxy = new WebProxy("10.44.224.69", 3128);
                webClient.Encoding = Encoding.UTF8;
                json = webClient.DownloadString("https://www.gov.uk/bank-holidays.json");
                JObject data = JObject.Parse(json);
                return data["england-and-wales"]["events"].Select(ev => 
                    new PublicHoliday() 
                    {
                        Name = (String)ev["title"],
                        HolidayDate = (DateTime)ev["date"]
                    }
                ).ToList();
            }
            
        }


    }
}
