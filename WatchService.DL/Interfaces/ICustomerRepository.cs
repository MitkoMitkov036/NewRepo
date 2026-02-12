using System;
using System.Collections.Generic;
using System.Text;

using WatchService.Models.Entities;

namespace WatchService.DL.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(string id);
    }
}
