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
    public class GetProductByIDUseCase : IGetProductByIDUseCase
    {
        private readonly IProductRepository productRepository;

        public GetProductByIDUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Execute(int productID)
        {
            return productRepository.GetProductByID(productID);
        }
    }
}
