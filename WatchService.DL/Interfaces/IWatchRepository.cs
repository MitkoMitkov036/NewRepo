using System;
using System.Collections.Generic;
using System.Text;

using WatchService.Models.Entities;

namespace WatchService.DL.Interfaces
{
    public interface IWatchRepository
    {
        Task AddAsync(Watch watch);
        Task<Watch?> GetByIdAsync(string id);
        Task<IEnumerable<Watch>> GetAllAsync();
        Task UpdateAsync(Watch watch);
    }
}
