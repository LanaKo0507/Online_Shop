﻿using OnlineShop.Db.Models;
using OnlineShop.Db.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ComparesDbRepository : ICompareRepository
    {
        private readonly DatabaseContext databaseContext;
        public ComparesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<Compare> AllCompares
        {
            get
            {
                return databaseContext.Compares;
            }
        }

        public void Add(Product product, string CompareId)
        {
            var userCompareList = TryGetByCompareId(CompareId);
            if (userCompareList == null)
            {
                AddNewCompare(product, CompareId);
            }
            else
            {
                var userCartItem = userCompareList.Items.FirstOrDefault(x => x.Id == product.Id);
                if (userCartItem == null)
                {
                    userCompareList.Items.Add(product);
                }
            }
        }

        public void Clear(string CompareId)
        {
            var result = TryGetByCompareId(CompareId);
            databaseContext.Remove(result);
            databaseContext.SaveChanges();
        }

        public void DeleteItem(Guid id, string CompareId)
        {
            var compare = TryGetByCompareId(CompareId);
            compare.Items.RemoveAll(x => x.Id == id);
            databaseContext.SaveChanges();
        }

        public Compare TryGetByCompareId(string CompareId)
        {
            return databaseContext.Compares.Find(CompareId);
        }
        private void AddNewCompare(Product product, string CompareId)
        {
            var newCart = new Compare
            {
                CompareId = CompareId,
                Items = new List<Product>(),
            };
            newCart.Items.Add(product);
            databaseContext.Compares.Add(newCart);
            databaseContext.SaveChanges();
        }
    }
}
