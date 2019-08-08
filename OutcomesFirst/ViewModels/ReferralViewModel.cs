using Microsoft.AspNetCore.Mvc;
using OutcomesFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OutcomesFirst.ViewModels
{
    public class ReferralViewModel
    {
        public int ReferralId { get; set; }

        [Required]
        [Display(Name = "ID")]
        [Remote(action: "VerifyReferralName", controller: "Referrals")]
        public string ReferralName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Range(1,4, ErrorMessage = "Please select gender")]
        [Display(Name = "Gender")]
        public int ReferralGenderId { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Range(1, 99, ErrorMessage = "Please select Local Authority")]

        [Display(Name = "Local Authority")]
        public int ReferralLocalAuthorityId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ReferralDOB { get; set; }

        public int DOBDay { get; set; }
        public int DOBMonth { get; set; }
        public int DOBYear { get; set; }


        [Display(Name = "Received Date")]
        [DataType(DataType.DateTime)]
        public DateTime ReferralReceivedDate { get; set; }

        [Range(1, 20, ErrorMessage = "Age must be between 1 and 20")]
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
        [Range(1, 99, ErrorMessage = "Please select Referral Type")]
        public int ReferralType { get; set; }

        public List<LocalAuthority> localAuthorities { get; set; }
        public List<Gender> genders { get; set; }
        public List<Status> statuses { get; set; }
        public List<string> referralTypes { get; set; }
        public List<ArchiveReason> archiveReasons { get; set; }
        public List<int> days { get; set; }
        public List<int> months { get; set; }
        public List<int> years { get; set; }

        public IEnumerable<Submission> Submissions { get; set; }

    }
}
