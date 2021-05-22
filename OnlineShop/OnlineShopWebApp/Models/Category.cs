﻿using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class Category
    {
        public static int Counter = 1;
        public int Id { get; }
        public string Name { get; set; }
        public List<Subcategory> Subcategory { get; set; }

        public Category (string name, List<Subcategory> subcategory)
        {
            Id = Counter;
            Name = name;
            Counter++;
            Subcategory = subcategory;
        }
    }
}
