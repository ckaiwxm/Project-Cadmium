using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.Models
{
    public class User : BaseEntity
    {
        public Guid? PublishVersion { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLoginTimestamp { get; set; }

        //public virtual ICollection<UserVersion> UserVersionList { get; set; }
        //public virtual ICollection<QuoteVersion> QuoteVersionList { get; set; }
    }
}
