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


        public long GetCycleTime(DateTime startDate)
        {
            return GetCycleTime(startDate, DateTime.Now);
        }

        public long GetCycleTime(DateTime startDate, DateTime endDate)
        {
            var localStartDate = LocalDateTime.FromDateTime(startDate.ToUniversalTime());
            var localEndDate = LocalDateTime.FromDateTime(endDate.ToUniversalTime());

            //Calculate Day diff first
            var cyclePeriod = Period.Between(localStartDate, localEndDate);
            var dayDifference = cyclePeriod.Days;

            for (var dayIndex = 0; dayIndex <= cyclePeriod.Days; dayIndex++)
            {
                if (localStartDate.PlusDays(dayIndex).IsoDayOfWeek == IsoDayOfWeek.Saturday || localStartDate.PlusDays(dayIndex).IsoDayOfWeek == IsoDayOfWeek.Sunday)
                {
                    dayDifference--;
                }
            }

            //Then calculate remaining hours
            var hourDifference = cyclePeriod.Hours;

            // Still pretty limited, will return bad data if 
            // the end date is on a weekend for example
            return dayDifference * 8 + (long)hourDifference;
        }

    }
}
