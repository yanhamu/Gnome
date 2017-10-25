using Gnome.Core.DataAccess;
using System;

namespace Gnome.Core.Service.Initialization
{
    public class ExpressionInitializeService : IInitializationService
    {
        private readonly IExpressionRepository repository;

        public int Order => 20;

        public ExpressionInitializeService(IExpressionRepository repository)
        {
            this.repository = repository;
        }

        public void Initialize(Guid userId)
        {
            repository.Create(new Model.Database.Expression()
            {
                Id = Guid.NewGuid(),
                ExpressionString = "1 = 1",
                Name = Constants.Expressions.All,
                UserId = userId
            });

            repository.Save();
        }
    }
}