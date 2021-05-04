using BillManager.Dal;
using BillManager.Dal.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillManager.Dal.Services
{
    public class MockDataStore : IDataStore<Bills>
    {
        readonly List<Bills> items;
        BillManagerDB db = new BillManagerDB();
        public MockDataStore()
        {
            try
            {
                string startDate = "28/04/2021";
              var startDateParse=  DateTime.ParseExact(startDate, "dd/MM/yyyy", null);

               items = new List<Bills>()
            {
                   new Bills { Description = "First item",Startdate=startDateParse.AddDays(2), Price=(decimal)29.99 },
                  new Bills { Description = "Second Item" ,Startdate= startDateParse, Price=(decimal)29.99 }

            };

            }catch(Exception ex)
            {


            }
             
        }

        public async Task<bool> AddBillsAsync(Bills item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateBillsAsync(Bills item)
        {
            var oldItem = items.Where((Bills arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteBillsAsync(int id)
        {
            var oldItem = items.Where((Bills arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Bills> GetBillsAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Bills>> GetBillsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
         
    }
}