using ProjectCadmium.Model.DomainClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.Configuration
{
    public class ClientConfigurations : EntityTypeConfiguration<Client>
    {
        public ClientConfigurations()
        {
            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255);

            Property(c => c.PricePerHour)
            .IsRequired();

            Property(c => c.LastUsedTimestamp)
            .IsRequired();

            HasMany(c => c.QuoteVersionList)
            .WithRequired(qv => qv.Client)
            .HasForeignKey(qv => qv.ClientID);
        }
    }
}