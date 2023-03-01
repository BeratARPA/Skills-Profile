using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SkillsProfile.Models.Class
{
    public partial class Contexts : DbContext
    {
        public Contexts() : base("name=EFContext")
        {
            Database.SetInitializer<Contexts>(new CreateDatabaseIfNotExists<Contexts>());
            //Database.SetInitializer<Contexts>(new DropCreateDatabaseIfModelChanges<Contexts>());
            //Database.SetInitializer<Contexts>(new DropCreateDatabaseAlways<Contexts>());
        }

        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<AdminUser> AdminUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}