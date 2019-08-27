using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutcomesFirst.Models

{
    public class Submission
    {
        public int SubmissionId { get; set; }

        [Display(Name = "ID")]
        public int SubmissionReferralId { get; set; }

        [Display(Name = "Service")]
       
        public int SubmissionServiceId { get; set; }

        [Display(Name = "Status")]
        public int? SubmissionStatusId { get; set; }

        //[NotMapped]
        //public bool IsChecked { get; set; }
       
 
        public virtual Referral SubmissionReferral { get; set; }
      
      
        public virtual Service SubmissionService { get; set; }

      
        public virtual Status SubmissionStatus { get; set; }



    }
}
