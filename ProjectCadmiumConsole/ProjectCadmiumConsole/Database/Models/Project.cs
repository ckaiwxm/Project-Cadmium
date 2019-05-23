using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.Models
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public DateTime LastUsedTimestamp { get; set; }

        //public virtual ICollection<QuoteVersion> QuoteVersionList { get; set; }
    }
}
