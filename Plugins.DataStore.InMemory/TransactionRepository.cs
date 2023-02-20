using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> transactions;
        public TransactionRepository()
        { 
            transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> GetAll(string cashierName,DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
                return transactions;
            else
                return transactions.Where(x => string.Equals(x.CashierName,cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
                return transactions.Where(x => x.Timestamp.Date == date.Date);
            else
                return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) && x.Timestamp.Date == date.Date); 
        }

        public void Save(string cashiername, int productID,string productName, double price, int priorqty, int soldqty)
        {
            int transactionID = 0;
            if(transactions!=null && transactions.Count > 0)
            {
                int maxID = transactions.Max(x => x.TransactionID);
                transactionID = maxID + 1;

            }
            else
            {
                transactionID = 1;
            }
            transactions.Add(new Transaction
            {
                TransactionID= transactionID,
                ProductID= productID,
                ProductName= productName,   
                Price= price,
                PriorQuantity = priorqty,
                SoldQuantity= soldqty,
                Timestamp = DateTime.Now,
                CashierName = cashiername
            });
        }
    }
}
