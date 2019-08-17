using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class GenderViewModel
    {
        public int GenderId { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string GenderName { get; set; }
    }
}
