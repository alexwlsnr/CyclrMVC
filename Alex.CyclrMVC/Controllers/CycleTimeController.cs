using Alex.CyclrMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NodaTime;

namespace Alex.CyclrMVC.Controllers
{
    public class CycleTimeController : ApiController
    {
        public Cycle Process(Cycle toProcess)
        {
            toProcess.CycleTime = 100;
            return toProcess;

        }


        public int GetCycleTime(DateTime startDate)
        {
            return GetCycleTime(startDate.ToUniversalTime(), DateTime.Now);
        }

        public int GetCycleTime(DateTime startDate, DateTime endDate)
        {
            var universalStartDate = startDate.ToUniversalTime();




            return 0;
        }

    }
}
