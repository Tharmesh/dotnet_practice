using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking;

namespace BANKING1.Repository
{
    public class Repository
    {
        public static List<AccountTransaction> accountTransactions;
        public static List<UPI_Transaction> uPI_Transactions;
        public static List<BankAccount> bankAccounts;
        public Repository() 
        {
            if (accountTransactions == null)
            {
                accountTransactions = new List<AccountTransaction>();
                uPI_Transactions = new List<UPI_Transaction>();
                bankAccounts = new List<BankAccount>();
            }
        }
        public static void addAccount(AccountTransaction controller)
        {
            Console.Clear();
            accountTransactions.Add(controller);
            Console.WriteLine("Data Successfully  Added in Transaction Account!!");
        }
        public static void CreateUPI(UPI_Transaction obj)
        {
            Console.Clear();
            uPI_Transactions.Add(obj);
            Console.WriteLine("Your UPI Account Created Successfully !!");
        }
        public int UPIAccountCount()
        { 
            return uPI_Transactions.Count;
        }
        public int AccountCount()
        { 
        return accountTransactions.Count;
        }
        public  AccountTransaction accountposition(int i)
        {
            return accountTransactions[i];
        }
        public UPI_Transaction upiposition(int i)
        {
            return uPI_Transactions[i];
        }
        public static void addAccount(BankAccount bank)
        {
            bankAccounts.Add(bank);
            Console.WriteLine("Your Account Successfully Added into the Bank Account !!");
        }
    }
}
