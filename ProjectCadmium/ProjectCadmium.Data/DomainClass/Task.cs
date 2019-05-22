using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.DomainClass
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public decimal Hours { get; set; }

        public Guid QuoteID { get; set; }
        public virtual Quote Quote
        { get; set; }
    }
}