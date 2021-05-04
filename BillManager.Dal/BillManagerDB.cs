using BillManager.Dal.Calendar;
using BillManager.Dal.Models;
using RecurrenceCalculator;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace BillManager.Dal
{
    public class BillManagerDB
    {
        private Calculator calendarUtility;
        private readonly DateTime startDate;
        readonly SQLiteAsyncConnection db;

        public const string DatabaseFilename = "BillManager.db";


        public BillManagerDB()
        {
            var mainDir = FileSystem.AppDataDirectory;
 
            db = new SQLiteAsyncConnection(DatabasePath);
            db.CreateTableAsync<Bills>().Wait();
            calendarUtility = new Calculator();

        }
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
        private AppointmentRecurrence CreateWeeklyRecurrence(DateTime starDate,DateTime endDate,int interval, RecurrenceType recurrenceType)
        {
            return new AppointmentRecurrence
            {
                RecurrenceType = recurrenceType,
                Interval = 1,
                Sunday = false,
                Monday = false,
                Tuesday = true,
                Wednesday = false,
                Thursday = true,
                Friday = false,
                Saturday = false,
                StartDate = starDate,
                EndDate =endDate
                
            };
        }
        public Task<List<Bills>> GetAllBills()
        {
            return db.Table<Bills>().ToListAsync();
        }

        public IEnumerable<DateTime> CreateOccourances(DateTime starDate, DateTime endDate, int interval, RecurrenceType recurrenceType)
        {

            var recurrence = CreateWeeklyRecurrence(starDate, endDate, interval, recurrenceType);
            return  calendarUtility.CalculateOccurrences(recurrence).ToList();

        }
        public Task<int> SaveBillItem(Bills bill)
        {
            if (bill.Id != 0)
            {
                // Update an existing note.
                return db.UpdateAsync(bill);
            }
            else
            {
                // Save a new note.
                return db.InsertAsync(bill);
            }
        }
        public async void DeleteAllTestDataAsync()
        {
            // Delete a note.
         await db.DeleteAllAsync<Bills>();
        }
        public Task<int> DeleteBillItemAsync(Bills bill)
        {
            // Delete a note.
            return db.DeleteAsync(bill);
        }



    }
}
