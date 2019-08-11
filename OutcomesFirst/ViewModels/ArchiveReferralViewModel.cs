using OutcomesFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class ArchiveReferralViewModel
    {
        public int ArchiveReferralId { get; set; }

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

        public string ArchiveReferralSuitableColor { get; set; }

        public bool? ArchiveReferralSuitable { get; set; }

        [Display(Name = "Archive Reason")]

        public int? ArchiveReferralArchiveReasonId { get; set; }

        [Display(Name = "Suitable Comments")]
        public string ArchiveReferralSuitableComments { get; set; }

        [Display(Name = "Not Suitable Comments")]
        public string ArchiveReferralNotSuitableComments { get; set; }



        public List<LocalAuthority> localAuthorities { get; set; }
        public List<Gender> genders { get; set; }
        public List<Status> statuses { get; set; }
        public List<string> referralTypes { get; set; }
        public List<ArchiveReason> archiveReasons { get; set; }

    }
}
