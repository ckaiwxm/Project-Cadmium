using ProjectCadmium.Model.DomainClass;
using ProjectCadmium.Model.Entities;
using ProjectCadmium.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCadmium.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new ProjectCadmiumEntities()))
            {
                // Get by ID
                Console.WriteLine("------------------------------------GET BY ID------------------------------------------------");
                var quote = unitOfWork.Quotes.Get(new Guid("7630CB8A-C484-420C-A1D4-6ECDF11A00DE"));
                Helper.PrintQuote(quote);

                // Get List
                Console.WriteLine("------------------------------------GET------------------------------------------------");
                var quoteLst = unitOfWork.Quotes.GetAll();
                Helper.PrintQuotes(quoteLst);

                // Insert
                Console.WriteLine("------------------------------------INSERT------------------------------------------------");
                Guid quoteID = Guid.NewGuid();
                quote = new Quote {
                    Id = quoteID,
                    PublishVersion = null,
                    NewPricePerHour = null
                };
                unitOfWork.Quotes.Insert(quote);

                unitOfWork.Commit();
                quoteLst = unitOfWork.Quotes.GetAll();
                Helper.PrintQuotes(quoteLst);

                // Update
                Console.WriteLine("------------------------------------UPDATE------------------------------------------------");
                quote = unitOfWork.Quotes.Find(q => q.Id == quoteID);
                quote.NewPricePerHour = 999m;

                unitOfWork.Commit();
                Helper.PrintQuote(quote);

                // Delete
                Console.WriteLine("------------------------------------DELETE------------------------------------------------");
                unitOfWork.Quotes.Delete(quote);

                unitOfWork.Commit();
                quoteLst = unitOfWork.Quotes.GetAll();
                Helper.PrintQuotes(quoteLst);
            }
        }
    }
}
