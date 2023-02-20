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
        private readonly IRecordTransactionsUseCase recordTransactionsUseCase;

        public SellProductUseCase(IProductRepository productRepository, IRecordTransactionsUseCase recordTransactionsUseCase)
        {
            this.productRepository = productRepository;
            this.recordTransactionsUseCase = recordTransactionsUseCase;
        }
        public void Execute(string cashiername, int productID, int sellQty)
        {
            var product = productRepository.GetProductByID(productID);
            if (productRepository == null) return;
            recordTransactionsUseCase.Execute(cashiername, productID, sellQty);
            product.Quantity -= sellQty;
            productRepository.UpdateProduct(product);

      
        }
    }
}
