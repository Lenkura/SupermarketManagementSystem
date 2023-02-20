using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CategoriesUseCase
{
    public class GetCategoryByIDUseCase : IGetCategoryByIDUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryByIDUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public Category Execute(int CategoryId)
        {
            return categoryRepository.GetCategoryByID(CategoryId);
        }
    }
}
