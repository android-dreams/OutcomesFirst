using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using OutcomesFirst.Models;

namespace OutcomesFirst.Models
{
    public class SubmitViewModel
    {
        public int ReferralId { get; set; }

        [Display(Name = "ID")]
        public string ReferralName { get; set; }

        [Display(Name = "Gender")]
        public int ReferralGenderId { get; set; }

        [Display(Name = "Local Authority")]
        public int ReferralLocalAuthorityId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime ReferralDOB { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Received Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime ReferralReceivedDate { get; set; }

        [Display(Name = "Age")]
        public int ReferralAge { get; set; }

        [Display(Name = "Comments")]
        public string ReferralComments { get; set; }

        [Display(Name = "Status")]
        public int ReferralStatusId { get; set; }

        public bool? ReferralSuitable { get; set; }

        [Display(Name = "Archive Reason")]
        public int? ReferralArchiveReasonId { get; set; }

        [Display(Name = "Comments")]
        public string ReferralSuitableComments { get; set; }
        [Display(Name = "Comments")]
        public string ReferralNotSuitableComments { get; set; }



        public LocalAuthority ReferralLocalAuthority { get; set; }
        public Gender ReferralGender { get; set; }
        public Status ReferralStatus { get; set; }
        public ArchiveReason ReferralArchiveReason { get; set; }
        public ICollection<Submission> Submissions { get; set; }

    }

}





