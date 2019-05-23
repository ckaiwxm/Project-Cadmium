using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.Models
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
