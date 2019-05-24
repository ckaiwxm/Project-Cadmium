using ProjectCadmium.Model.Entities;
using ProjectCadmium.Model.Interfaces;
using System;

namespace ProjectCadmium.Model.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectCadmiumEntities projectCadmiumEntities;
        public IQuoteRepository Quotes { get; private set; }

        public UnitOfWork(ProjectCadmiumEntities projectCadmiumEntities)
        {
            this.projectCadmiumEntities = projectCadmiumEntities;
            this.Quotes = new QuoteRepository(projectCadmiumEntities);
        }

        public int Commit()
        {
            return projectCadmiumEntities.SaveChanges();
        }

        public void Dispose()
        {
            projectCadmiumEntities.Dispose();
        }
    }
}