using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductUseCase;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class RecordTransactionsUseCase : IRecordTransactionsUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetProductByIDUseCase getProductByIDUseCase;

        public RecordTransactionsUseCase(ITransactionRepository transactionRepository, IGetProductByIDUseCase getProductByIDUseCase)
        {
            this.transactionRepository = transactionRepository;
            this.getProductByIDUseCase = getProductByIDUseCase;
        }
        public void Execute(string cashiername, int productID, int qty)
        {
            var product = getProductByIDUseCase.Execute(productID);
            transactionRepository.Save(cashiername, productID, product.Name, product.Price.Value, product.Quantity.Value, qty);
        }
    }
}
