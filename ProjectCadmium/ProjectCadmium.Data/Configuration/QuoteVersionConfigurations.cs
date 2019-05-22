using ProjectCadmium.Model.DomainClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.Configuration
{
    public class QuoteVersionConfigurations : EntityTypeConfiguration<QuoteVersion>
    {
        public QuoteVersionConfigurations()
        {
            Property(qv => qv.UniqueID)
            .IsRequired()
            .HasMaxLength(50);

            Property(qv => qv.Version)
            .IsRequired();

            Property(qv => qv.IsBillable)
            .IsRequired();

            Property(qv => qv.CreationDate)
            .IsRequired();

            Property(qv => qv.CreatedById)
            .IsOptional();
        }
    }
}