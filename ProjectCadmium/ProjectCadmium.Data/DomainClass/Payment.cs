using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.DomainClass
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Guid QuoteID { get; set; }
        public virtual Quote Quote { get; set; }
    }
}