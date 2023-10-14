﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db.Models.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByUserIdAsync(string userId);
        Task AddAsync(Guid id, string userId = null);
        Task DeleteAsync(Guid id, string userId = null);
        Task EditAsync(Guid id, string userId = null);
        Task ClearAsync(string userId);
        Task<int> GetCountAsync(string userId);
        Task CreateAsync(string userId);
    }
}