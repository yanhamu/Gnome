using Gnome.Core.Model;

namespace Gnome.Core.DataAccess
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {

    }

    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(GnomeDb context) : base(context)
        {
        }
    }
}
