using System;
using System.Collections.Generic;
using System.Text;

using WatchService.Models.Responses;

namespace WatchService.BL.Interfaces
{
    public interface ISellWatchService
    {
        Task<SellWatchResponse> SellAsync(string watchId, string customerId);
    }
}
