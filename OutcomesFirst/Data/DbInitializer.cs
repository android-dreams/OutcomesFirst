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
                new Region{RegionName="West Midlands",RegionRegionalManagerId=1},
                new Region{RegionName="LONDON",RegionRegionalManagerId=2},
                new Region{RegionName="SOUTH EAST",RegionRegionalManagerId=2},
                new Region{RegionName="SOUTH WEST",RegionRegionalManagerId=2},
                new Region{RegionName="WALES",RegionRegionalManagerId=2},
                new Region{RegionName="OTHER",RegionRegionalManagerId=2}

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
            new LocalAuthority{LocalAuthorityName="Barking and Dagenham",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Barnet",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Barnsley",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Bath and North East Somerset ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Bedford ",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Berkshire",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Bexley",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Birmingham",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Blackburn with Darwen ",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Blackpool ",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Blaenau Gwent",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Bolton",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Bournemouth ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Bracknell Forest ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Bradford",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Brent",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Bridgend ",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Brighton and Hove ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Bristol City",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Bromley",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Buckinghamshire ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Burnley",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Bury",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Caerphilly",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Cafcass",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Calderdale",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Cambridgeshire ",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Camden",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Cardiff",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Carmarthenshire",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Central Bedfordshire ",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Ceredigion",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Cheshire East ",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Cheshire West and Chester ",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="City of London",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Cleveland - Redcar",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Conwy",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Cornwall ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Coventry",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Croydon",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Cumbria ",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Darlington",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Denbighshire",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Derby ",LocalAuthorityRegionId=3},
            new LocalAuthority{LocalAuthorityName="Derbyshire ",LocalAuthorityRegionId=3},
            new LocalAuthority{LocalAuthorityName="Devon ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Doncaster",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Dorset ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Dudley ",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Dumfries",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Durham",LocalAuthorityRegionId=10},
            new LocalAuthority{LocalAuthorityName="Ealing",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="East Midlands",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="East Riding of Yorkshire ",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="East Sussex ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Enfield",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Essex ",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Flintshire",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Gateshead",LocalAuthorityRegionId=10},
            new LocalAuthority{LocalAuthorityName="Glamorgan",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Gloucestershire ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Greenwich",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Guernsey",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Gwent",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Gwynedd",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Hackney",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Halton ",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Hammersmith and Fulham",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Hampshire ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Haringey",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Harlow",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Harrow",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Hartlepool",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Havering",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Herefordshire",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Hertfordshire",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Hillingdon",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Hounslow",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Huddersfield",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Hull City",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="International",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Isle of Anglesey",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Isle of Man",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Isle of Wight ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Isles of Scilly ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Islington",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Jersey",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Kensington and Chelsea",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Kent ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Kingston upon Thames",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Kirklees",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Knowsley ",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Lambeth",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Lancashire ",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Leeds",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Leicester ",LocalAuthorityRegionId=3},
            new LocalAuthority{LocalAuthorityName="Leicestershire",LocalAuthorityRegionId=3},
            new LocalAuthority{LocalAuthorityName="Lewisham",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Lincolnshire",LocalAuthorityRegionId=3},
            new LocalAuthority{LocalAuthorityName="Liverpool",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Living Autism",LocalAuthorityRegionId=10},
            new LocalAuthority{LocalAuthorityName="Luton ",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Manchester",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Medway ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Merthyr Tydfil",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Merton",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Middlesborough",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Milton Keynes ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Monmouthshire",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Neath Port Talbot",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Newcastle City Council",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Newham",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Newport",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Norfolk",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="North East Lincolnshire ",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="North Lincolnshire ",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="North Somerset ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="North Tyneside",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="North Yorkshire ",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Northamptonshire",LocalAuthorityRegionId=3},
            new LocalAuthority{LocalAuthorityName="Northern Ireland",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Northumberland",LocalAuthorityRegionId=10},
            new LocalAuthority{LocalAuthorityName="Nottingham City",LocalAuthorityRegionId=3},
            new LocalAuthority{LocalAuthorityName="Nottinghamshire ",LocalAuthorityRegionId=3},
            new LocalAuthority{LocalAuthorityName="Oldham ",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Oxford & Central",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Oxfordshire",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Pembrokeshire",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Pengower",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Peterborough ",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Plymouth ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Poole ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Portsmouth ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Powys",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Reading ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Redbridge",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Rhondda Cynon Taf",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Richmond upon Thames",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Rochdale",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Rotherham ",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Rutland ",LocalAuthorityRegionId=3},
            new LocalAuthority{LocalAuthorityName="Salford",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Sandwell ",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Scarborough",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Scotland",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Sefton",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Sheffield",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Shropshire ",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Slough ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Solihull",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Somerset",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="South Gloucestershire ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="South Tyneside",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="South West London",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Southampton",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Southend",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Southend-on-Sea ",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Southern Region",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Southwark",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="St. Helens",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Staffordshire",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Stevenage",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Stockport",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Stockton",LocalAuthorityRegionId=10},
            new LocalAuthority{LocalAuthorityName="Stoke-on-Trent",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Suffolk",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Sunderland",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Surrey",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Sutton",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Sutton Coldfield",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Swansea",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Swindon ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Tameside",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Telford and Wrekin ",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="The Vale of Glamorgan",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Thurrock ",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="Torbay ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Torfaen",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="Tower Hamlets",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Trafford",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Unknown",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Wakefield",LocalAuthorityRegionId=2},
            new LocalAuthority{LocalAuthorityName="Walsall",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Waltham Forest",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Wandsworth",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Warrington ",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Warwickshire",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="West Berkshire ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="West Midlands",LocalAuthorityRegionId=5},
            new LocalAuthority{LocalAuthorityName="West Sussex",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Westminster",LocalAuthorityRegionId=6},
            new LocalAuthority{LocalAuthorityName="Wigan",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Wiltshire ",LocalAuthorityRegionId=8},
            new LocalAuthority{LocalAuthorityName="Windsor and Maidenhead ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Wirral",LocalAuthorityRegionId=1},
            new LocalAuthority{LocalAuthorityName="Wokingham ",LocalAuthorityRegionId=7},
            new LocalAuthority{LocalAuthorityName="Wolverhampton",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Worcestershire ",LocalAuthorityRegionId=4},
            new LocalAuthority{LocalAuthorityName="Wrexham",LocalAuthorityRegionId=9},
            new LocalAuthority{LocalAuthorityName="York City",LocalAuthorityRegionId=2}

            };

            foreach (LocalAuthority la in localauthorities)
            {
                context.LocalAuthority.Add(la);
            }
            context.SaveChanges();

            var refstatus = new Status[]
           {
                new Status{StatusName="Placed",StatusPriority=1},
                new Status{StatusName="Archive",StatusPriority=2},
                new Status{StatusName="Confirmed pending start date",StatusPriority=3},
                new Status{StatusName="Offered",StatusPriority=4},
                new Status{StatusName="In Correspondence with LA",StatusPriority=5},
                new Status{StatusName="Assessment/Visit Stage",StatusPriority=6},
                new Status{StatusName="In correspondence with family",StatusPriority=7},
                new Status{StatusName="Under Consideration by Service", StatusPriority=8}
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

