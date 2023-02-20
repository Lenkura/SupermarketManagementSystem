using CoreBusiness;
using System.Security.Cryptography.X509Certificates;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository() 
        {
            //Default Categories
            categories = new List<Category>()
            {
                new Category {CategoryID = 1, Name = "Beverage", Description = "Beverage" },
                new Category {CategoryID = 2, Name = "Bakery", Description = "Bakery" },
                new Category {CategoryID = 3, Name = "Meat", Description = "Meat" },
   
            };
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            if (categories != null && categories.Count() > 0)
            {
                var maxID = categories.Max(x => x.CategoryID);
                category.CategoryID = maxID + 1;
            }
            else
            {
                category.CategoryID = 1;
            }
            categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryByID(category.CategoryID);
            if (categoryToUpdate != null) 
            {
               categoryToUpdate.Name = category.Name;
               categoryToUpdate.Description = category.Description;
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public Category GetCategoryByID(int categoryID)
        {
           return categories?.FirstOrDefault(x => x.CategoryID == categoryID);
        }

        public void DeleteCategory(int categoryID)
        {
            categories.Remove(GetCategoryByID(categoryID));
        }
    }
}