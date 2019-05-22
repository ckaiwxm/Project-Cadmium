using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectCadmium.Model.Configuration;
using ProjectCadmium.Model.DomainClass;

namespace ProjectCadmium.Model.Entities
{
    public class ProjectCadmiumEntities : DbContext
    {
        public ProjectCadmiumEntities() : base("name=ProjectCadmiumEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<QuoteVersion> QuoteVersions { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserVersion> UserVersions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectConfigurations())
                                       .Add(new ClientConfigurations())
                                       .Add(new TaskConfigurations())
                                       .Add(new QuoteVersionConfigurations())
                                       .Add(new QuoteConfigurations())
                                       .Add(new PaymentConfigurations())
                                       .Add(new UserVersionConfigurations())
                                       .Add(new UserConfigurations());
        }
    }
}