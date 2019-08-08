using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutcomesFirst.Models
{
    public class Gender
    {

        public int GenderId { get; set; }
        [Display(Name = "Gender")]
        public string GenderName { get; set; }
    }
}
