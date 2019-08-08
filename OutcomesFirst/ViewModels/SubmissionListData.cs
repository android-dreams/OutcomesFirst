using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OutcomesFirst.Models;


namespace OutcomesFirst.ViewModels
{
    public class SubmissionListData
    {
        public string Title { get; set; }
        public string Header { get; set; }
        public int MVReferralId { get; set; }
        public string MVReferralName { get; set; }
        public string MVGender { get; set; }
        public int MVAge { get; set; }
        public string MVLocalAuthority { get; set; }
        public DateTime MVDateReceived { get; set; }

       

        public bool MVIsChecked { get; set; }

        // public Referral Referral { get; set;  }

        public Submission Submission { get; set; }

        public virtual ICollection<Service> Services { get; set; }


    }
}
