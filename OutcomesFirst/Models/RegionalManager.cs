using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OutcomesFirst.Models
{
    public class RegionalManager
    {
        public int RegionalManagerId { get; set; }

        [Display(Name ="Regional Manager")]
        public string RegionalManagerName { get; set; }

    }
}
