using ProjectCadmium.Model.DomainClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.Configuration
{
    public class UserConfigurations : EntityTypeConfiguration<User>
    {
        public UserConfigurations()
        {
            Property(u => u.PublishVersion)
            .IsOptional();

            Property(u => u.IsActive)
            .IsRequired();

            Property(u => u.LastLoginTimestamp)
            .IsRequired();

            HasMany(u => u.UserVersionList)
            .WithRequired(uv => uv.User)
            .HasForeignKey(uv => uv.UserID);

            HasMany(u => u.QuoteVersionList)
            .WithRequired(qv => qv.CreatedBy)
            .HasForeignKey(qv => qv.CreatedById);
        }
    }
}