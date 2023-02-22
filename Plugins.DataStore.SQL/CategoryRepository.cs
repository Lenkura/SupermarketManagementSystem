using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository : ICategoryRepository 
    { 
        private readonly MarketContext db;

        public CategoryRepository(MarketContext db) 
        { 
            this.db = db;
        }
    
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int CategoryID)
        {
            var cat = db.Categories.Find(CategoryID);
            if (cat == null) return;

            db.Categories.Remove(cat);
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryByID(int CategoryID)
        {
            return db.Categories.Find(CategoryID);
        }

        public void UpdateCategory(Category category)
        {
            var cat = db.Categories.Find(category.CategoryID);
            cat.Name = category.Name;
            cat.Description = category.Description;
            db.SaveChanges();
           // db.Categories.Update(category);
        }
    }
}
