using Gnome.Core.Model.Database;

namespace Gnome.Core.DataAccess
{
    public interface IExpressionRepository : IGenericRepository<Expression> { }

    public class ExpressionRepository : GenericRepository<Expression>, IExpressionRepository
    {
        public ExpressionRepository(GnomeDb context) : base(context) { }
    }
}