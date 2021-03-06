﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

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


        //[DataType(DataType.Date)]
        //[Display(Name = "Start Date")]
        //public DateTime SubmissionPlacementStartDate { get; set; }



        [Display(Name = "Archive Reason")]
      
      
        public int? SubmissionArchiveReasonId { get; set; }

        [NotMapped]
        public List<string> IsChecked { get; set; }

     
        public virtual Referral SubmissionReferral { get; set; }

     
        public virtual Service SubmissionService { get; set; }


        public virtual Status SubmissionStatus { get; set; }

        public virtual ArchiveReason SubmissionArchiveReason { get; set; }




    }
}
