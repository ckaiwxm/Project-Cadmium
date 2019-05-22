using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using ProjectCadmium.Model.DomainClass;
using System.Web;

namespace ProjectCadmium.Model.Configuration
{
    public class TaskConfigurations : EntityTypeConfiguration<Task>
    {
        public TaskConfigurations()
        {
            Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(255);

            Property(t => t.Hours)
            .IsRequired();

        }
    }
}