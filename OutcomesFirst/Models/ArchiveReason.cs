using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OutcomesFirst.Models
{
    public class ArchiveReason
    {
        [Display(Name = "Select Archive Reason")]
        public int ArchiveReasonId { get; set; }

        [Display(Name = "Archive Reason")]
        [Required]
        public string ArchiveReasonName { get; set; }
        [Display(Name = "Decision By ")]
        [Required]
        public int ArchiveDecisionBy { get; set; }
    }
}



