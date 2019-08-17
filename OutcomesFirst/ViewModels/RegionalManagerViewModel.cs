using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class RegionalManagerViewModel
    {
        public int RegionalManagerId { get; set; }

        [Required]
        [Display(Name = "Regional Manager")]
        public string RegionalManagerName { get; set; }
    }
}
