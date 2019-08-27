using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class StatusViewModel
    {

        public int StatusId { get; set; }

        [Display(Name = "Status")]
        [Required]
        public string StatusName { get; set; }

        [Display(Name = "Priority")]
        [Required]
        public int StatusPriority { get; set; }
        public int StatusOffersActivityReportOrder { get; set; }

    }
}
