using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Transaction
    {
        public int TransactionID {get;set;}
        public DateTime Timestamp { get;set;}
        public int ProductID { get;set;}
        public string ProductName { get; set; }
        public double Price { get;set;}
        public int PriorQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public string CashierName { get; set;}
        
    }
}
