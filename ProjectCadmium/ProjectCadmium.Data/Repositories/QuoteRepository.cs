using ProjectCadmium.Model.DomainClass;
using ProjectCadmium.Model.Entities;
using ProjectCadmium.Model.Interfaces;

namespace ProjectCadmium.Model.Repositories
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {

        public QuoteRepository(ProjectCadmiumEntities projectCadmiumEntities) : base(projectCadmiumEntities)
        {
        }
    }
}