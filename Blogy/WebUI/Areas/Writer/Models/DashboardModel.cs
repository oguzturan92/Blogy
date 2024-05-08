using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Writer.Models
{
    public class DashboardModel
    {
        public Forecasts[] forecasts { get; set; }
        public class Forecasts
        {
            public string day { get; set; }
            public int high { get; set; }
            public string text { get; set; }
        }

    }
}