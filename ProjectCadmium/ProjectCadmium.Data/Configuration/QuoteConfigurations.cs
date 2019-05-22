using ProjectCadmium.Model.DomainClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.Configuration
{
    public class QuoteConfigurations : EntityTypeConfiguration<Quote>
    {
        public QuoteConfigurations()
        {
            Property(q => q.PublishVersion)
            .IsOptional();

            Property(q => q.NewPricePerHour)
            .IsOptional();

            HasMany(q => q.QuoteVersionList)
            .WithRequired(qv => qv.Quote)
            .HasForeignKey(qv => qv.QuoteID);

            HasMany(q => q.PaymentList)
            .WithRequired(p => p.Quote)
            .HasForeignKey(p => p.QuoteID);

            HasMany(q => q.TaskList)
            .WithRequired(t => t.Quote)
            .HasForeignKey(t => t.QuoteID);
        }
    }
}