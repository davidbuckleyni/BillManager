using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillManager.Dal.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddBillsAsync(T item);
        Task<bool> UpdateBillsAsync(T item);
        Task<bool> DeleteBillsAsync(int id);
        Task<T> GetBillsAsync(int id);
        Task<IEnumerable<T>> GetBillsAsync(bool forceRefresh = false);
    }
}
