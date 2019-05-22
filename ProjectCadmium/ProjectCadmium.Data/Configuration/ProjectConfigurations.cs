using ProjectCadmium.Model.DomainClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.Configuration
{
    public class ProjectConfigurations : EntityTypeConfiguration<Project>
    {
        public ProjectConfigurations()
        {
            Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

            Property(p => p.LastUsedTimestamp)
            .IsRequired();

            HasMany(p => p.QuoteVersionList)
            .WithRequired(qv => qv.Project)
            .HasForeignKey(qv => qv.ProjectID);
        }
    }
}