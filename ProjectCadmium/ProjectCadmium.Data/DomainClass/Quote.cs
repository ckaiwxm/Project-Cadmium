using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectCadmium.Model.DomainClass
{
    public class Quote : BaseEntity
    {
        public Guid PublishVersion { get; set; }
        public decimal NewPricePerHour { get; set; }

        public virtual ICollection<QuoteVersion> QuoteVersionList { get; set; }
        public virtual ICollection<Payment> PaymentList { get; set; }
        public virtual ICollection<Task> TaskList { get; set; }
    }
}