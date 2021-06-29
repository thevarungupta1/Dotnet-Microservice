using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Models
{
    public class ProductMockImpl: IProductRepository
    {
        private static List<Product> products;
        private int count = 3;
        public ProductMockImpl()
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "Product 1", Description = "Description 1" });
            products.Add(new Product() { Id = 2, Name = "Product 2", Description = "Description 2" });
            products.Add(new Product() { Id = 3, Name = "Product 3", Description = "Description 3" });
        }

        public Product AddProduct(Product product)
        {
            product.Id = ++count;
            products.Add(product);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}
