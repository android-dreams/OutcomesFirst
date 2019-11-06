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
    public class ArchiveReferral
    {
        public int ArchiveReferralId { get; set; }

        [Display(Name="ReferralId")]
        public int OriginalReferralId { get; set; }

        [Display(Name = "ID")]
        public string ArchiveReferralName { get; set; }

      
        [Display(Name = "Gender")]
        public int ArchiveReferralGenderId { get; set; }

        [Display(Name = "Type")]
        public int ArchiveReferralType { get; set; }


        [Display(Name = "Local Authority")]
        public int? ArchiveReferralLocalAuthorityId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Received Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime ArchiveReferralReceivedDate { get; set; }

        [Display(Name = "Age")]
        public int ArchiveReferralAge { get; set; }

        [Display(Name = "Comments")]
        public string ArchiveReferralComments { get; set; }

        [Display(Name = "Status")]
   
        public int ArchiveReferralStatusId { get; set; }

        public bool? ArchiveReferralSuitable { get; set; }

        [Display(Name = "Archive Reason")]
    
        public int? ArchiveReferralArchiveReasonId { get; set; }

        [Display(Name = "Comments")]
        public string ArchiveReferralSuitableComments { get; set; }

        [Display(Name = "Comments")]
        public string ArchiveReferralNotSuitableComments { get; set; }



        public LocalAuthority ArchiveReferralLocalAuthority { get; set; }
        public Gender ArchiveReferralGender { get; set; }
        public Status ArchiveReferralStatus { get; set; }
        public ArchiveReason ArchiveReferralArchiveReason { get; set; }



    }
}






