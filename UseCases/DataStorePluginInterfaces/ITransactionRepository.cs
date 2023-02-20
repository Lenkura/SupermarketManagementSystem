﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        void Save(string cashiername, int productID,string productName, double price, int priorqty, int soldqty);
        IEnumerable<Transaction> GetByDay(string cashierName, DateTime date);
        IEnumerable<Transaction> GetAll(string cashierName,DateTime date);
    }
}
