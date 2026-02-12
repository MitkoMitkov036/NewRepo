using System;
using System.Collections.Generic;
using System.Text;

using WatchService.Models.Entities;
using WatchService.Models.Requests;

namespace WatchService.BL.Interfaces
{
    public interface IWatchCrudService
    {
        Task AddAsync(AddWatchRequest request);
        Task<IEnumerable<Watch>> GetAllAsync();
        Task<Watch?> GetByIdAsync(string id);
    }
}
