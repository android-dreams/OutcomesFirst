﻿using OutcomesFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomesFirst.ViewModels
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }

        [Display(Name = "Service")]
        public string ServiceName { get; set; }

        [Display(Name = "Address")]
        public string ServiceAddress1 { get; set; }

        [Display(Name = " ")]
        public string ServiceAddress2 { get; set; }

        [Display(Name = " ")]
        public string ServiceAddress3 { get; set; }

        [Display(Name = " ")]
        public string ServiceAddress4 { get; set; }

        [Display(Name = "Postcode")]
        public string ServicePostcode { get; set; }

        [Display(Name = "Region")]
        public int? ServiceRegionId { get; set; }

        [Display(Name = "Contact")]
        public string ServiceContact { get; set; }

        [Display(Name = "Contact Number")]
        public string ServiceContactNumber { get; set; }

        [Display(Name = "Number of Places")]
        public int ServicePlaces { get; set; }


        public virtual Region Region { get; set; }
    }
}