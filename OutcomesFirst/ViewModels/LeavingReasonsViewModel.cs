using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class LeavingReasonsViewModel
    {

        public int LeavingReasonId { get; set; }

        [Display(Name="Leaving Reason")]
        [Required]
        public string LeavingReasonName { get; set; }

    }
}
