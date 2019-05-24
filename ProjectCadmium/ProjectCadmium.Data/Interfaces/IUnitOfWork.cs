using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmium.Model.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IQuoteRepository Quotes { get; }
        int Commit();
    }
}
