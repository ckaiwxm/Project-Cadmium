using ProjectCadmium.Model.DomainClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.Configuration
{
    public class PaymentConfigurations : EntityTypeConfiguration<Payment>
    {
        public PaymentConfigurations()
        {
            Property(p => p.Amount)
            .IsRequired();

            Property(p => p.PaymentDate)
            .IsRequired();
        }
    }
}