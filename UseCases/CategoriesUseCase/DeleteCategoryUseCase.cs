using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CategoriesUseCase
{

    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public DeleteCategoryUseCase(ICategoryRepository CategoryRepository)
        {
            categoryRepository = CategoryRepository;
        }
        public void Delete(int categoryID)
        {
            categoryRepository.DeleteCategory(categoryID);
        }
    }
}
