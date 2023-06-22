using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class AccountTransaction
    {
        public AccountTransaction() { }
        public string AccNo { get; set; }
        public string AccName { get; set; }
        public float AccBal { get; set; }

        public void insertAccData(BankAccount bac)
        {
            AccNo= bac.AccountNumber;
            AccName = bac.AccountName;
            AccBal = bac.AccountBalance;
        }

        
    }
}
