using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductUseCase
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;

        public SellProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Execute(int productID, int sellQty)
        {
            var product = productRepository.GetProductByID(productID);
            if (productRepository == null) return;

            product.Quantity -= sellQty;
            productRepository.UpdateProduct(product);
        }
    }
}
