using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace XF_Mid2_Lab1
{
    public class AddressOperations
    {
        readonly SQLiteAsyncConnection db;

        public AddressOperations(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Address1>().Wait();
            db.CreateTableAsync<Person1>().Wait();
        }
        //Get all Address.
        public Task<List<Address1>> GetAllAddressAsync()
        {

            return db.Table<Address1>().ToListAsync();
        }       
        // Get a specific address by HomeNumber and City. 
        public Task<Address1> GetAddressAsync(string home, string city)
        {
            return db.Table<Address1>().Where(i => i.HomeNumber == home && i.City == city).FirstOrDefaultAsync();
        }

        // ============================================================
        public Task<Person1> GetPersonAsync(string name)
        {
            return db.Table<Person1>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }
         
        public Task<Person1> GetPersonAsync(int id)
        {
            return db.Table<Person1>().Where(i => i.AId == id).FirstOrDefaultAsync();
        }
        public Task<Address1> GetAddressAsync(string home)
        {
            return db.Table<Address1>().Where(i => i.HomeNumber == home).FirstOrDefaultAsync();
        }

        public Task<int> SavePersonAsync(Person1 person)
        {
            if (person.Id != 0)
            {
                // Update an existing address.
                return db.UpdateAsync(person);
            }
            else
            {
                // Save a new address.
                return db.InsertAsync(person);
            }
        }

        // ============================================================


        // Get all people living in address by HomeNumber and City.
        public Task<List<Address1>> GetAllPeopleAddressAsync(string home, string city)
        {
            return db.Table<Address1>().Where(i => i.HomeNumber == home && i.City == city).ToListAsync();
        }

        public Task<int> SaveAddressAsync(Address1 address)
        {
            if (address.Id != 0)
            {
                // Update an existing address.
                return db.UpdateAsync(address);
            }
            else
            {
                // Save a new address.
                return db.InsertAsync(address);
            }
        }
        // Delete address.
        public Task<int> DeleteAddressAsync(Address1 address)
        {
            return db.DeleteAsync(address);
        }

        // Delete address.
        public Task<int> DeletePersonAsync(Person1 person)
        {
            return db.DeleteAsync(person);
        }
    }
}
