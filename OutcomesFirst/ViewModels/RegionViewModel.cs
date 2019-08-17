using OutcomesFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class RegionViewModel
    {
        public int RegionId { get; set; }

        [Display(Name = "Region")]
        public string RegionName { get; set; }

        [Display(Name = "Regional Manager")]
        [Required]
        public int RegionRegionalManagerId { get; set; }

        public virtual RegionalManager RegionalManager { get; set; }

        public List<RegionalManager> regionalManagers { get; set; }

    }
}
