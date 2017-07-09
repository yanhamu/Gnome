using System.Collections.Generic;
using Fio.Core.Model;

namespace Fio.Downloader.DataAccess
{
    public interface ITransactionRepository
    {
        void SaveTransaction(int accountId, Transaction transaction);
    }
}