using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmiumConsole.Database.Models
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Guid QuoteID { get; set; }
        //public virtual Quote Quote { get; set; }
    }
}
