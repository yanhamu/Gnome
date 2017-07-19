using Gnome.Core.Model;
using System.Collections.Generic;

namespace Gnome.Core.Service.Interfaces
{
    public interface ITransactionService
    {
        List<FlatTransaction> GetTransactions(int accountId, int limit);
    }
}
