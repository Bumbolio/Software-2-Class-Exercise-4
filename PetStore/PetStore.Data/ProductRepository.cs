using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _ctx;

        public ProductRepository() {
            _ctx = new ProductContext();
        }


        public void AddProduct(Product product) {
            _ctx.Products.Add(product);
            _ctx.SaveChanges(); 
        }

        public Product GetProductById(Guid productId)
        {
            var product = _ctx.Products.Find(productId);
            return product;
        }

        public Product GetProductByName(string productName)
        {
            var product = _ctx.Products.FirstOrDefault(product => product.Name == productName);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            var products = _ctx.Products.ToList();
            return products;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

    }

    public interface IProductRepository : IDisposable
    { 
        void AddProduct(Product product);
        Product GetProductById(Guid ProductId);
        Product GetProductByName(string ProductName);
        List<Product> GetAllProducts();
    }
}
