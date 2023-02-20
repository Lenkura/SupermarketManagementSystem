using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductUseCase
{
    public class ViewProductsByCategoryID : IViewProductsByCategoryID
    {
        private readonly IProductRepository productRepository;

        public ViewProductsByCategoryID(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(int CategoryID)
        {
            return productRepository.GetProductsByCategoryID(CategoryID);
        }
    }
}
