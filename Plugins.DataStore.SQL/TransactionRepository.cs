using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionRepository(MarketContext db) 
        {
            this.db = db;
        }

        public IEnumerable<Transaction> Get()
        {
            return db.Transaction.ToList();
        }

        public IEnumerable<Transaction> GetAllCashier(string cashierName)
        {
            if (string.IsNullOrEmpty(cashierName))
                return db.Transaction.ToList();
            else
                return db.Transaction.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
                return db.Transaction.Where(x => x.Timestamp.Date == date.Date);
            else
                return db.Transaction.Where(x => x.CashierName.ToLower() == cashierName.ToLower() && x.Timestamp.Date == date.Date);
        }

        public void Save(string cashiername, int productID, string productName, double price, int priorqty, int soldqty)
        {
            var transaction = new Transaction
            {
                ProductID = productID,
                ProductName = productName,
                Timestamp = DateTime.Now,
                Price = price,
                PriorQuantity= priorqty,
                SoldQuantity= soldqty,
                CashierName= cashiername,
            };

            db.Transaction.Add(transaction);
            db.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
                return db.Transaction.Where(x => x.Timestamp >= startDate.Date && x.Timestamp <= endDate.Date.AddDays(1).Date);
            else
                return db.Transaction.Where(x => x.CashierName.ToLower() == cashierName.ToLower() && x.Timestamp >= startDate.Date && x.Timestamp <= endDate.Date.AddDays(1).Date);
        }
    }
}
