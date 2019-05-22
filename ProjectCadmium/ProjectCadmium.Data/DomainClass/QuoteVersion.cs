using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectCadmium.Model.DomainClass
{
    public class QuoteVersion : PublishCreateMetadata
    {
        public string UniqueID { get; set; }
        public Guid Version { get; set; }
        public bool IsBillable { get; set; }

        public Guid QuoteID { get; set; }
        public virtual Quote Quote { get; set; }

        public States Status { get; set; }

        public Guid ProjectID { get; set; }
        public virtual Project Project { get; set; }

        public Guid ClientID { get; set; }
        public virtual Client Client { get; set; }

    }
}