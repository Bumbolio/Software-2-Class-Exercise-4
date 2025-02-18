﻿using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Logic
{
    internal interface IProductLogic
    {
        /// <summary>
        /// Add a product to the stores inventory
        /// </summary>
        /// <param name="product">The product that will be added.  It can be a derived type of Product</param>
        public void AddProduct(Product product);

        /// <summary>
        /// Get all the products for the store
        /// </summary>
        public List<Product> GetAllProducts();

        /// <summary>
        /// Gets a product by the name of the product
        /// </summary>
        /// <param name="name">The name given to the product.  It can include spaces</param>
        public Product GetProductByName(string name);
    }
}
