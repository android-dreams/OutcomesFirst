using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class ArchiveReasonViewModel
    {
        public int ArchiveReasonId { get; set; }

        [Display(Name = "Archive Reason")]
        [Required]
        public string ArchiveReasonName { get; set; }

        [Display(Name = "Decision By ")]
        [Range(1, 99, ErrorMessage = "The Decision By field is required")]
        [Required]
        public int ArchiveDecisionBy { get; set; }
        
    }
}
