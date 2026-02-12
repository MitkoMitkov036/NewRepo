using System;
using System.Collections.Generic;
using System.Text;

using WatchService.BL.Interfaces;
using WatchService.DL.Interfaces;
using WatchService.Models.Responses;

namespace WatchService.BL.Services
{
    public class SellWatchService : ISellWatchService
    {
        private readonly IWatchRepository _watchRepository;
        private readonly ICustomerRepository _customerRepository;

        public SellWatchService(
            IWatchRepository watchRepository,
            ICustomerRepository customerRepository)
        {
            _watchRepository = watchRepository;
            _customerRepository = customerRepository;
        }

        public async Task<SellWatchResponse> SellAsync(string watchId, string customerId)
        {
            var watch = await _watchRepository.GetByIdAsync(watchId);
            if (watch == null)
            {
                return new SellWatchResponse
                {
                    IsSuccessful = false,
                    Message = "Watch not found"
                };
            }

            if (watch.StockQuantity <= 0)
            {
                return new SellWatchResponse
                {
                    IsSuccessful = false,
                    Message = "Watch is out of stock"
                };
            }

            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                return new SellWatchResponse
                {
                    IsSuccessful = false,
                    Message = "Customer not found"
                };
            }

            watch.StockQuantity--;
            await _watchRepository.UpdateAsync(watch);

            return new SellWatchResponse
            {
                IsSuccessful = true,
                Message = "Watch sold successfully"
            };
        }
    }
}
