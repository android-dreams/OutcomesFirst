using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OutcomesFirst.Data;
using OutcomesFirst.Models;

namespace OutcomesFirst.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //context.Database.EnsureCreated();

            //Look for any Genders
            if (context.Gender.Any())
            {
                return; //DB has been seeded{
            }


            var regions = new Region[]
          {
            
                 new Region{RegionName="South", RegionRegionalManagerId=1},
                 new Region{RegionName="Oxfordshire",RegionRegionalManagerId=2},
                 new Region{RegionName="West Berkshire",RegionRegionalManagerId=3},
                 new Region{RegionName="East Midlands",RegionRegionalManagerId=4},
                 new Region{RegionName="West Midlands",RegionRegionalManagerId=1}

          };
            foreach (Region g in regions)
            {
                context.Region.Add(g);
               
            }
            context.SaveChanges();


            var leavingReasons = new LeavingReason[]
  {

                 new LeavingReason{LeavingReasonName="Increased level of risk"},
                 new LeavingReason{LeavingReasonName="Returned home"},
                 new LeavingReason{LeavingReasonName="Transition to foster care"},
                 new LeavingReason{LeavingReasonName="Age-related leaver"},
                 new LeavingReason{LeavingReasonName="Geography"},
                 new LeavingReason{LeavingReasonName="Internal Transfer within group"},
                 new LeavingReason{LeavingReasonName="LA Decision"},
                 new LeavingReason{LeavingReasonName="Other"}


  };
            foreach (LeavingReason g in leavingReasons)
            {
                context.LeavingReason.Add(g);

            }
            context.SaveChanges();




            var regionalManager = new RegionalManager[] 
            {
                new RegionalManager{RegionalManagerName="Rodrigo Ferreira"},
                new RegionalManager{RegionalManagerName="James Cliff"},
                new RegionalManager{RegionalManagerName="Jarrod Elcock"},
                new RegionalManager{RegionalManagerName="Sam Millward"},

            };
            foreach (RegionalManager r in regionalManager)
            {
                context.RegionalManager.Add(r);
               
            }
            context.SaveChanges();

            var genders = new Gender[]       
            {                //new Gender{GenderName="---enter gender---"}, 

                new Gender{GenderName="Male"},
                new Gender{GenderName="Female"},
                new Gender{GenderName="Transgender"},
                 new Gender{GenderName="Other"}

            };

            foreach (Gender g in genders)
            {
                context.Gender.Add(g);
            }
            context.SaveChanges();

           
            var localauthorities = new LocalAuthority[]
            {
                 new LocalAuthority{LocalAuthorityName="Stoke-on-Trent"},
                 new LocalAuthority{LocalAuthorityName="Southampton"},
                 new LocalAuthority{LocalAuthorityName="Staffordshire"},
                 new LocalAuthority{LocalAuthorityName="West Midlands"},
                 new LocalAuthority{LocalAuthorityName="East Midlands"},
                 new LocalAuthority{LocalAuthorityName="Berkshire"},
                 new LocalAuthority{LocalAuthorityName="Oxford & Central"},
                 new LocalAuthority{LocalAuthorityName="Southern Region"}
                 
            };

            foreach (LocalAuthority la in localauthorities)
            {
                context.LocalAuthority.Add(la);
            }
            context.SaveChanges();

            var refstatus = new Status[]
           {
                new Status{StatusName="Confirmed pending start date",StatusPriority=1},
                new Status{StatusName="Offered",StatusPriority=2},
                new Status{StatusName="In Correspondence with LA",StatusPriority=3},
                new Status{StatusName="Assessment/Visit Stage",StatusPriority=4},
                new Status{StatusName="In correspondence with family",StatusPriority=5},
                new Status{StatusName="Under Consideration by Service", StatusPriority=6},
                new Status{StatusName="Placed",StatusPriority=7},
                new Status{StatusName="Archive",StatusPriority=8}
                
              
           };

            foreach (Status r in refstatus)
            {
                context.Status.Add(r);
            }
            context.SaveChanges();




            var serv = new Service[]
         {
                 new Service{ServiceName="Acorn Cottage",ServiceRegionId=1,ServicePlaces=10},
                 new Service{ServiceName="Aqueduct House",ServiceRegionId=2,ServicePlaces=20},
                 new Service{ServiceName="Ash House",ServiceRegionId=3,ServicePlaces=12},
                 new Service{ServiceName="Ashley",ServiceRegionId=4,ServicePlaces=11},
                 new Service{ServiceName="Barnfield Lodge",ServiceRegionId=1,ServicePlaces=15},
                 new Service{ServiceName="The Bartons",ServiceRegionId=2,ServicePlaces=16},
                 new Service{ServiceName="Beachlands",ServiceRegionId=3,ServicePlaces=12},
                 new Service{ServiceName="The Birches",ServiceRegionId=4,ServicePlaces=15},
                 new Service{ServiceName="Denmead",ServiceRegionId=1,ServicePlaces=12},
                 new Service{ServiceName="Eyton House",ServiceRegionId=2,ServicePlaces=19},
                 new Service{ServiceName="Haven Lodge",ServiceRegionId=3,ServicePlaces=18},
                 new Service{ServiceName="Hayling Island",ServiceRegionId=4,ServicePlaces=17},
                 new Service{ServiceName="The Laurels",ServiceRegionId=1,ServicePlaces=16},
                 new Service{ServiceName="The Meadows",ServiceRegionId=2,ServicePlaces=15},
                 new Service{ServiceName="The Moorlands",ServiceRegionId=3,ServicePlaces=14},
                 new Service{ServiceName="Newlands",ServiceRegionId=4,ServicePlaces=13},
                 new Service{ServiceName="Oathill Loadge",ServiceRegionId=1,ServicePlaces=12},
                 new Service{ServiceName="The Paddocks",ServiceRegionId=2,ServicePlaces=11},
                 new Service{ServiceName="Park Farm",ServiceRegionId=3,ServicePlaces=10},
                 new Service{ServiceName="Poppy Lodge",ServiceRegionId=4,ServicePlaces=9},
                 new Service{ServiceName="Spinney House",ServiceRegionId=1,ServicePlaces=10},
                 new Service{ServiceName="Steps",ServiceRegionId=2,ServicePlaces=11},
                 new Service{ServiceName="Sunnycroft",ServiceRegionId=3,ServicePlaces=30},
                 new Service{ServiceName="Villa Farm House",ServiceRegionId=4,ServicePlaces=40},
                 new Service{ServiceName="Weaveley",ServiceRegionId=1,ServicePlaces=13},
                 new Service{ServiceName="Ramsworth Cottage",ServiceRegionId=2,ServicePlaces=25},
                 new Service{ServiceName="Jubilee School",ServiceRegionId=3,ServicePlaces=28},
                 new Service{ServiceName="New Barn School",ServiceRegionId=4,ServicePlaces=15},
                 new Service{ServiceName="Manor House School",ServiceRegionId=1,ServicePlaces=16},
                 new Service{ServiceName="Shifnal School",ServiceRegionId=2,ServicePlaces=18},
                 new Service{ServiceName="Park School",ServiceRegionId=3,ServicePlaces=20 },


         };

            foreach (Service r in serv)
            {
                context.Service.Add(r);
            }
            context.SaveChanges();






            var arcreason = new ArchiveReason[]
          {
                new ArchiveReason{ArchiveReasonName="Too high risk",ArchiveDecisionBy=1},
                new ArchiveReason{ArchiveReasonName="Unable to meet the timescales",ArchiveDecisionBy=2},
                new ArchiveReason{ArchiveReasonName="Not Compatible",ArchiveDecisionBy=3},
                new ArchiveReason{ArchiveReasonName="Placed Elsewhere",ArchiveDecisionBy=4},
                new ArchiveReason{ArchiveReasonName="Family Preference",ArchiveDecisionBy=4},
                new ArchiveReason{ArchiveReasonName="Cost",ArchiveDecisionBy=4},
                new ArchiveReason{ArchiveReasonName="OFSTED rating",ArchiveDecisionBy=4},
                new ArchiveReason{ArchiveReasonName="Wrong Location - LA decison",ArchiveDecisionBy=4},
                new ArchiveReason{ArchiveReasonName="Wrong Location - Our decision",ArchiveDecisionBy=3},
                new ArchiveReason{ArchiveReasonName="Referral withdrawn",ArchiveDecisionBy=1},
                new ArchiveReason{ArchiveReasonName="No reason given",ArchiveDecisionBy=2},
                new ArchiveReason{ArchiveReasonName="Unsuitable following assessment",ArchiveDecisionBy=1},
                new ArchiveReason{ArchiveReasonName="Timescales",ArchiveDecisionBy=2},
                new ArchiveReason{ArchiveReasonName="Insufficient resources at this time",ArchiveDecisionBy=3},
                new ArchiveReason{ArchiveReasonName="Other",ArchiveDecisionBy=4}
          };

            foreach (ArchiveReason a in arcreason)
            {
                context.ArchiveReason.Add(a);
            }
            context.SaveChanges();

           
        }
    }
}

