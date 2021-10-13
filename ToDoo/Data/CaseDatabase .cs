using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using ToDoo.Models;

namespace ToDoo.Data
{
    public class CaseDatabase
    {
        readonly SQLiteAsyncConnection database;

        public CaseDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Case>().Wait();
        }

        public Task<List<Case>> GetCasesAsync()
        {
            return database.Table<Case>().ToListAsync();
        }

        public Task<Case> GetCaseAsync(int id)
        {
            return database.Table<Case>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCaseAsync(Case _case)
        {
            if (_case.ID != 0)
            {
                return database.UpdateAsync(_case);
            }
            else
            {
                return database.InsertAsync(_case);
            }
        }

        public Task<int> DeleteCaseAsync(Case _case)
        {
            return database.DeleteAsync(_case);
        }
    }
}
