﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public class ComparesDbRepository : ICompareRepository
    {
        private readonly DatabaseContext databaseContext;
        public ComparesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Compare>> AllCompares()
        {
                return await databaseContext.Compares.ToListAsync();
        }

        public async Task Add(Product product, string UserId)
        {
            var userCompareList = await TryGetByCompareId(UserId);
            if (userCompareList == null)
            {
                await AddNewCompare(product, UserId);
            }
            else
            {
                var userCartItem = userCompareList.Items.FirstOrDefault(x => x.Id == product.Id);
                if (userCartItem == null)
                {
                    userCompareList.Items.Add(product);
                }
            }
            await databaseContext.SaveChangesAsync();
        }

        public async Task Clear(string CompareId)
        {
            var result = TryGetByCompareId(CompareId);
            databaseContext.Remove(result);
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteItem(Guid id, string CompareId)
        {
            var compare = await TryGetByCompareId(CompareId);
            compare.Items.RemoveAll(x => x.Id == id);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Compare> TryGetByCompareId(string CompareId)
        {
            return await databaseContext.Compares.Include(x => x.Items).FirstOrDefaultAsync(x => x.UserId == CompareId);
        }
        private async Task AddNewCompare(Product product, string userId)
        {
            var newCart = new Compare
            {
                UserId = userId,
                Items = new List<Product>(),
            };
            newCart.Items.Add(product);
            databaseContext.Compares.Add(newCart);
            await databaseContext.SaveChangesAsync();
        }
    }
}
