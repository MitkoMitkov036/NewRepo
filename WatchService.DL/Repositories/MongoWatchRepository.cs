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
    public class MongoWatchRepository : IWatchRepository
    {
        private readonly IMongoCollection<Watch> _collection;

        public MongoWatchRepository(IOptionsMonitor<MongoDbConfiguration> options)
        {
            var client = new MongoClient(options.CurrentValue.ConnectionString);
            var database = client.GetDatabase(options.CurrentValue.DatabaseName);
            _collection = database.GetCollection<Watch>("watches");
        }

        public async Task AddAsync(Watch watch)
            => await _collection.InsertOneAsync(watch);

        public async Task<Watch?> GetByIdAsync(string id)
            => await _collection.Find(w => w.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Watch>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();

        public async Task UpdateAsync(Watch watch)
            => await _collection.ReplaceOneAsync(w => w.Id == watch.Id, watch);
    }
}
