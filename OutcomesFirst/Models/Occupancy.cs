using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutcomesFirst.Models
{
    public class Occupancy
    {
        public int OccupancyId { get; set; }

        [Display(Name = "Referral ID")]
        public string OccupancyRefId { get; set; }


        [Display(Name = "First Name")]
        public string OccupancyFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string OccupancyLastName { get; set; }

        [Display(Name = "Gender")]
        public int OccupancyGenderId { get; set; }

        [Display(Name = "Residental")]
        public char OccupancyType { get; set; }

        [Display(Name = "Service Transition")]
        public bool? OccupancyServiceTransition { get; set; }

        [Display(Name = "Service")]

        [ForeignKey("OccupancyServiceId")]
        public int OccupancyServiceId { get; set; }

       
        [Display(Name = "Date Started With Group")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-mm-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime OccupancyDateStartedWithGroup { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Stated With placement")]
        public DateTime? OccupancyPlacementStartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime OccupancyDOB { get; set; }

        [Display(Name = "Age at Leaving")]
        public int? OccupancyAgeAtLeaving { get; set; }

        [Display(Name = "Local Authority")]
        public int OccupancyLocalAuthorityId { get; set; }

        [Display(Name = "Framework")]
        public string OccupancyFramework { get; set; }

        [Display(Name = "Weekly Fee")]
        public int? OccupancyWeeklyFee { get; set; }

        [Display(Name = "Length of Stay With Group")]
        public int? OccupancyLengthOfStayWithGroup { get; set; }

        [Display(Name = "Length of Stay With Placement")]
        public int? OccupancyLengthOfStayWithPlacement { get; set; }

        [Display(Name = "Notes")]
        public string OccupancyNotes { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Leave Date")]
        public DateTime? OccupancyLeaveDate { get; set; }

        [Display(Name = "Good/Bad Leaver")]
        public string OccupancyLeaverType { get; set; }

        [Display(Name = "Reason for Leaving")]
        public int? OccupancyReasonForLeavingID { get; set; }

        public Gender OccupancyGender { get; set; }
        public Service  OccupancyService { get; set; }
        public LocalAuthority OccupancyLocalAuthority { get; set; }
      
    }
}