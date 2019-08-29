using OutcomesFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class SubmissionViewModel
    {
        public int SubmissionId { get; set; }

        [Display(Name = "ID")]
        public int SubmissionReferralId { get; set; }

        [Display(Name = "Service")]
        public int SubmissionServiceId { get; set; }

        [Display(Name = "Status")]
        public int? SubmissionStatusId { get; set; }


        public IList<Region> regions { get; set; }
        public IList<ServiceViewModel> services { get; set; }

    }
}
