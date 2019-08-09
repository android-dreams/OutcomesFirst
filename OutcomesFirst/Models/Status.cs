using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OutcomesFirst.Models
{
    public class Status
    {

        public int StatusId { get; set; }
        
        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [Display(Name="Priority")]
        public int StatusPriority { get; set; }
        public int StatusOffersActivityReportOrder { get; set; }
        
    }
}
