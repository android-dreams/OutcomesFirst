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

        [NotMapped]
        public List<string> IsChecked { get; set; }


        public virtual Referral SubmissionReferral { get; set; }


        public virtual Service SubmissionService { get; set; }


        public virtual Status SubmissionStatus { get; set; }
    }
}
