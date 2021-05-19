﻿using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>()
        {
                    new Product("Плюшевый мишка", 300, "Плюшевый мишка – символ нежности, трогательной заботы, " +
        "тепла. Многим он знаком с первых лет жизни.", "/img/Products/1.jpg","Мягкие игрушки"),
                    new Product("Конструктор", 1000, "Любознательным малышам придется по душе конструктор.", "/img/Products/2.jpg", "Конструкторы"),
                    new Product("Пирамидка стаканчики", 200, "Пирамидка собирается из стаканчиков разного размера. " +
                "Только соблюдая четкую последовательность от большего стаканчика к меньшему у малыша получится башенка", "/img/Products/3.jpg", "Пирамидки"),
                    new Product("Водный пистолет", 150, "Длагодаря водному пистолету можно весело играть в друзьями летом на лужайке", "/img/Products/4.jpg", "Игрушечное оружие"),
                    new Product("Мяч детский", 170, "Мяч выполнен из прочного ПВХ и подходит для активных игр как дома, так и на воздухе", "/img/Products/5.jpg", "Мячи")
                };
        public IEnumerable<Product> AllProducts
        {
            get
            {
                return products;
            }
        }
        public Product GetProductById(int id)
        {
            return AllProducts.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteItem(int id)
        {
            products.RemoveAll(x => x.Id == id);
        }
        public void Edit(Product editProduct)
        {
            var product = AllProducts.FirstOrDefault(p => p.Id == editProduct.Id);
            product.Name = editProduct.Name;
            product.Cost = editProduct.Cost;
            product.Description = editProduct.Description;
        }
        public int GetCount()
        {
            return products.Count;
        }
        public void Add(Product newProduct)
        {
            var product = new Product(newProduct.Name, newProduct.Cost, newProduct.Description, "/img/Products/empty.gif", newProduct.CategoryItem);
            products.Add(product);
        }

        public List<Product> SeachProduct(string[] seachResults)
        {
            var resultList = new List<Product>();

            foreach (var word in seachResults)
            {
            resultList = products.Where(x => x.Name.ToLower().Contains(word.ToLower())).ToList();
            }
            return resultList.Distinct().ToList();
        }
        public List<Product> SeachCategory(string categoryItem)
        {
            return products.Where(x => x.CategoryItem == categoryItem).ToList();
        }

    }
}
