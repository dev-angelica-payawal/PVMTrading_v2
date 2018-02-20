using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.ViewModels
{
    public class Item
    {
        public Product product = new Product();

        public Product Product { get;set;}
  
        public int Quantity { get; set; }

        public double Price { get; set; }

        public Item()
        { }

        public Item(Product product, int quantity,double price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;

        }
    }
}