using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;
        public ProductInMemoryRepository()
        {
            products = new List<Product>()
            {
                new Product { ProductID = 1, CategoryID = 1, Name = "Iced Tea", Price = 1.99, Quantity = 100 },
                new Product { ProductID = 2, CategoryID = 1, Name = "Ginger Ale", Price = 4.99, Quantity = 200 },
                new Product { ProductID = 3, CategoryID = 2, Name = "Wholemeal Bread", Price = 2.00, Quantity = 300 },
                new Product { ProductID = 4, CategoryID = 2, Name = "White Bread", Price = 1.00, Quantity = 300 },
                new Product { ProductID = 5, CategoryID = 3, Name = "Lamb", Price = 15.00, Quantity = 25 },
                new Product { ProductID = 6, CategoryID = 3, Name = "Beef", Price = 9.50, Quantity = 50 }
            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (products != null && products.Count() > 0)
            {
                var maxID = products.Max(x => x.ProductID);
                product.ProductID = maxID + 1;
            }
            else
            {
                product.ProductID = 1;
            }
            products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductByID(product.ProductID);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.CategoryID = product.CategoryID;
                productToUpdate.Price = product.Price;
                productToUpdate.Quantity = product.Quantity;
            }
        }

        public Product GetProductByID(int productID)
        {
            return products.FirstOrDefault(x=>x.ProductID == productID);
        }

        public void DeleteProduct(int productID)
        {
           var toDelete = GetProductByID(productID);
            if (toDelete !=null)
                products.Remove(toDelete);
        }

        public IEnumerable<Product> GetProductsByCategoryID(int CategoryID)
        {
            return products.Where(x => x.CategoryID == CategoryID);
        }
    }
}
