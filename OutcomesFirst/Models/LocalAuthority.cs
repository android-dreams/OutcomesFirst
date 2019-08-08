using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutcomesFirst.Models
{
    public class LocalAuthority
    {

        public int LocalAuthorityId { get; set; }
        [Display(Name = "Local Authority")]
        public string LocalAuthorityName { get; set; }
        [Display(Name = "Region")]
     
        public int? LocalAuthorityRegionId { get; set; }

        public Region LocalAuthorityRegion { get; set; }

    }
}
