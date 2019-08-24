using OutcomesFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class PlacementViewModel
    {
        public int PlacementId { get; set; }

        [Display(Name = "Referral ID")]
        public string PlacementRefId { get; set; }


        [Display(Name = "First Name")]
        public string PlacementFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string PlacementLastName { get; set; }

        [Display(Name = "Gender")]
        public int PlacementGenderId { get; set; }

        [Display(Name = "Residental")]
        public int PlacementType { get; set; }

        [Display(Name = "Service Transition")]
        public bool? PlacementServiceTransition { get; set; }

        [Display(Name = "Service")]
        public int PlacementServiceId { get; set; }


        [Display(Name = "Date Started With Group")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PlacementDateStartedWithGroup { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Placement Start Date")]
        public DateTime? PlacementPlacementStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime PlacementDOB { get; set; }

        [Display(Name = "Age at Leaving")]
        public int? PlacementAgeAtLeaving { get; set; }

        [Display(Name = "Local Authority")]
        public int PlacementLocalAuthorityId { get; set; }

        [Display(Name = "Framework")]
        public string PlacementFramework { get; set; }

        [Display(Name = "Weekly Fee")]
        public int? PlacementWeeklyFee { get; set; }

        [Display(Name = "Group Length of Stay")]
        public int? PlacementLengthOfStayWithGroup { get; set; }

        [Display(Name = "Placement Length of Stay")]
        public int? PlacementLengthOfStayWithPlacement { get; set; }

        [Display(Name = "Notes")]
        public string PlacementNotes { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Leave Date")]
        public DateTime? PlacementLeaveDate { get; set; }

        [Display(Name = "Good/Bad Leaver")]
        public string PlacementLeaverType { get; set; }

        [Display(Name = "Reason for Leaving")]
        public int? PlacementLeavingReasonId { get; set; }

        [ForeignKey("PlacementGenderId")]
        public Gender Gender { get; set; }


        [ForeignKey("PlacementServiceId")]
        public Service Service { get; set; }

        [ForeignKey("PlacementLocalAuthorityId")]
        public LocalAuthority LocalAuthority { get; set; }


        [ForeignKey("PlacementLeavingReasonId")]
        public LeavingReason LeavingReason { get; set; }
    }
}
