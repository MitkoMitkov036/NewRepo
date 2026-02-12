using System;
using System.Collections.Generic;
using System.Text;

using WatchService.BL.Interfaces;
using WatchService.DL.Interfaces;
using WatchService.Models.Entities;
using WatchService.Models.Requests;

namespace WatchService.BL.Services
{
    public class WatchCrudService : IWatchCrudService
    {
        private readonly IWatchRepository _watchRepository;

        public WatchCrudService(IWatchRepository watchRepository)
        {
            _watchRepository = watchRepository;
        }

        public async Task AddAsync(AddWatchRequest request)
        {
            var watch = new Watch
            {
                Brand = request.Brand,
                Model = request.Model,
                Price = request.Price,
                Type = request.Type,
                StockQuantity = request.StockQuantity
            };

            await _watchRepository.AddAsync(watch);
        }

        public async Task<IEnumerable<Watch>> GetAllAsync()
            => await _watchRepository.GetAllAsync();

        public async Task<Watch?> GetByIdAsync(string id)
            => await _watchRepository.GetByIdAsync(id);
    }
}
