using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OutcomesFirst.Models;

namespace OutcomesFirst.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OutcomesFirst.Models.ArchiveReason> ArchiveReason { get; set; }
        public DbSet<OutcomesFirst.Models.Gender> Gender { get; set; }
        public DbSet<OutcomesFirst.Models.LocalAuthority> LocalAuthority { get; set; }
        public DbSet<OutcomesFirst.Models.Region> Region { get; set; }
        public DbSet<OutcomesFirst.Models.Referral> Referral { get; set; }
        public DbSet<OutcomesFirst.Models.ArchiveReferral> ArchiveReferral { get; set; }
        public DbSet<OutcomesFirst.Models.Status> Status { get; set; }
        public DbSet<OutcomesFirst.Models.Service> Service { get; set; }
        public DbSet<OutcomesFirst.Models.Submission> Submission { get; set; }
        public DbSet<OutcomesFirst.Models.Placement> Placement { get; set; }
        public DbSet<OutcomesFirst.Models.RegionalManager> RegionalManager { get; set; }
        public DbSet<OutcomesFirst.Models.LeavingReason> LeavingReason { get; set; }

        internal object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
