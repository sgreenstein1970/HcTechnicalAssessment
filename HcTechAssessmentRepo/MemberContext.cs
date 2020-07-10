
using System.Configuration;

namespace HcTechAssessmentRepo

{
    using System;
    //using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Configuration;

    public partial class MemberContext : DbContext,IMemberContext
    {
        public MemberContext(DbContextOptions<MemberContext> options) : base(options)
        {
         //options.s
        }


        public virtual DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.LastName)
                .IsUnicode(false);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            { 
                optionsBuilder.UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Enrollment.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            }

        }

    }


}
