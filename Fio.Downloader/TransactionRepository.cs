using System;
using System.Threading.Tasks;
using Fio.Core.Model;

namespace Fio.Downloader
{
    internal class TransactionRepository
    {
        private object accountId;

        public TransactionRepository(object accountId)
        {
            this.accountId = accountId;
        }

        internal void SaveAll(Task<Transactions> transactions)
        {
            throw new NotImplementedException();
        }
    }
}