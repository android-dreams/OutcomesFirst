using OutcomesFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class LocalAuthorityViewModel
    {
        public int LocalAuthorityId { get; set; }
        [Display(Name = "Local Authority")]

        [Required]
        public string LocalAuthorityName { get; set; }

        [Display(Name = "Region")]
        [Required]
        [Range(1, 99, ErrorMessage = "This field is required")]

        public int? LocalAuthorityRegionId { get; set; }

        public Region Region { get; set; }

        public List<Region> regions { get; set; }

    }
}
