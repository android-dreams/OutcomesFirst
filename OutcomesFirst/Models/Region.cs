using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public int RegionRegionalManagerId { get; set; }

        public virtual RegionalManager RegionalManager { get; set; }
    }
}
