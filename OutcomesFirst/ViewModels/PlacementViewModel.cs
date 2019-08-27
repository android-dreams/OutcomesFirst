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
        [Required]
        public string PlacementFirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string PlacementLastName { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public int PlacementGenderId { get; set; }

        [Display(Name = "Placement Type")]
        [Required]
        public int PlacementType { get; set; }

        [Display(Name = "Service Transition")]
        public bool? PlacementServiceTransition { get; set; }

        [Display(Name = "Service")]
        [Required]
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
        [Required]
        public DateTime PlacementDOB { get; set; }
        public int PlacementDOBDay { get; set; }
        public int PlacementDOBMonth { get; set; }
        public int PlacementDOBYear { get; set; }

        [Display(Name = "Age at Leaving")]
        [Range(0, 19, ErrorMessage = "Leaving age must be between 0 and 19")]
        public int? PlacementAgeAtLeaving { get; set; }

        [Display(Name = "Local Authority")]
        [Required]
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

        [Range(1, 99, ErrorMessage = "Please select Reason for Leaving")]
        [Display(Name = "Reason for Leaving")]
        public int? PlacementLeavingReasonId { get; set; }



        public List<LocalAuthority> localAuthorities { get; set; }
        public List<LeavingReason> leavingReasons { get; set; }
        public List<Gender> genders { get; set; }

        public List<int> years { get; set; }
        public List<int> months { get; set; }
        public List<int> days { get; set; }

    }
}
