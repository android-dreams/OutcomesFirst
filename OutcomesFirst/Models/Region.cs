using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutcomesFirst.Models
{
    public class Region
    {
        public int RegionId { get; set; }

        [Display(Name = "Region")]
        public string RegionName { get; set; }

        [Display(Name = "Regional Manager")]
        public int RegionRegionalManagerId { get; set; }

      
        public virtual RegionalManager RegionalManager { get; set; }
    }
}
