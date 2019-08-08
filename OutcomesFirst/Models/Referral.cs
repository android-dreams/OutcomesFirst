using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutcomesFirst.Models
{
    public class Referral
    {
      
        public int ReferralId { get; set; }

        [Required]
        [Display(Name = "ID")]
        public string ReferralName { get; set; }


        [Display(Name = "Gender")]
     
        public int ReferralGenderId { get; set; }

        [Display(Name = "Local Authority")]
     
        public int ReferralLocalAuthorityId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReferralDOB { get; set; }

     
        [Display(Name = "Received Date")]
        [DataType(DataType.DateTime)]
        public DateTime ReferralReceivedDate { get; set; } 

            
        [Display(Name = "Age")]
        public int ReferralAge { get; set; }

        [Display(Name = "Comments")]
        public string ReferralComments { get; set; }

        [Display(Name = "Status")]
     
        public int ReferralStatusId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Placement Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? ReferralPlacementStartDate { get; set; }

  
        public string ReferralSuitableColor { get; set; }

     
        public bool? ReferralSuitable { get; set; }

        [Display(Name = "Archive Reason")]
      
        public int? ReferralArchiveReasonId { get; set; }

        [Display(Name = "Comments")]
        public string ReferralSuitableComments { get; set; }
        [Display(Name = "Comments")]
        public string ReferralNotSuitableComments { get; set; }

        [Display(Name = "Referral Type")]
        public int ReferralType { get; set; }

        public  LocalAuthority ReferralLocalAuthority { get; set; }
        public Gender ReferralGender { get; set; }
        public Status ReferralStatus { get; set; }
        public ArchiveReason ReferralArchiveReason { get; set; }

        public IEnumerable<Submission> Submissions { get; set; }


    }

}




