using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext db;

        public ProductRepository(MarketContext db) 
        {
            this.db = db;
        }
        public void AddProduct(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(int productID)
        {
            var pro = db.Product.Find(productID);
            if (pro == null) return;

            db.Product.Remove(pro);
            db.SaveChanges();
        }

        public Product GetProductByID(int productID)
        {
            return db.Product.Find(productID);
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.Product.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryID(int CategoryID)
        {
            return db.Product.Where(x => x.CategoryID == CategoryID).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var pro = db.Product.Find(product.ProductID);
            pro.CategoryID = product.CategoryID;
            pro.Name = product.Name;
            pro.Price= product.Price;
            pro.Quantity= product.Quantity;
            db.SaveChanges();
        }
    }
}
