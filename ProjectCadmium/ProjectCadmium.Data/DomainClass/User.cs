using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectCadmium.Model.DomainClass
{
    public class User : BaseEntity
    {
        public Guid PublishVersion { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLoginTimestamp { get; set; }

        public virtual ICollection<UserVersion> UserVersionList { get; set; }
        public virtual ICollection<QuoteVersion> QuoteVersionList { get; set; }
    }
}