using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.DomainClass
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public DateTime LastUsedTimestamp { get; set; }

        public virtual ICollection<QuoteVersion> QuoteVersionList { get; set; }
    }
}