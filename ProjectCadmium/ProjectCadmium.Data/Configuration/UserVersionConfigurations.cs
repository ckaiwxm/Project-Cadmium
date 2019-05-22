using ProjectCadmium.Model.DomainClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.Configuration
{
    public class UserVersionConfigurations : EntityTypeConfiguration<UserVersion>
    {
        public UserVersionConfigurations()
        {
            Property(uv => uv.Version)
            .IsRequired();

            Property(uv => uv.UserName)
            .IsRequired()
            .HasMaxLength(150);

            Property(uv => uv.Password)
            .IsRequired()
            .HasMaxLength(150);

            Property(uv => uv.FirstName)
            .IsRequired()
            .HasMaxLength(150);

            Property(uv => uv.LastName)
            .IsRequired()
            .HasMaxLength(150);

            Property(uv => uv.Phone)
            .IsOptional ()
            .HasMaxLength(50);

            Property(uv => uv.Email)
            .IsOptional()
            .HasMaxLength(50);

            Property(uv => uv.CreationDate)
            .IsRequired();
        }
    }
}