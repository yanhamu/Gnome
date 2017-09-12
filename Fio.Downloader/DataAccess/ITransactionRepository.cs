using Gnome.Core.Model;
using System.Threading.Tasks;

namespace Fio.Downloader.DataAccess
{
    public interface ITransactionRepository
    {
        Task SaveTransaction(Transaction transaction);
    }
}