using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using OutcomesFirst.Models;

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

        [DataType(DataType.Date)]
        [Display(Name="Start Date")]
        public DateTime?  SubmissionPlacementStartDate { get; set; }


   
        [Display(Name = "Archive Reason")]
      
        public int? SubmissionArchiveReasonId { get; set; }

        [NotMapped]
        public List<string> IsChecked { get; set; }


        public virtual Referral SubmissionReferral { get; set; }
        public virtual Service SubmissionService { get; set; }


        public List<Status> Statuses { get; set; }
        public List<string> ReferralTypes { get; set; }
        public List<ArchiveReason> ArchiveReasons { get; set; }
        public List<Service> Services { get; set; }

    }
}
