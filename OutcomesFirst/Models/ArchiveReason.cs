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
        public int ArchiveReasonId { get; set; }
        [Display(Name = "Archive Reason")]
        public string ArchiveReasonName { get; set; }
        [Display(Name = "Decision By ")]
        public int ArchiveDecisionBy { get; set; }
    }
}



