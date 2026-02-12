using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Driver;
using Microsoft.Extensions.Options;
using WatchService.DL.Interfaces;
using WatchService.Models.Entities;
using WatchService.Models.Configurations;

namespace WatchService.DL.Repositories
{
    public class MongoCustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _collection;

        public MongoCustomerRepository(IOptionsMonitor<MongoDbConfiguration> options)
        {
            var client = new MongoClient(options.CurrentValue.ConnectionString);
            var database = client.GetDatabase(options.CurrentValue.DatabaseName);
            _collection = database.GetCollection<Customer>("customers");
        }

        public async Task<Customer?> GetByIdAsync(string id)
            => await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
    }
}
