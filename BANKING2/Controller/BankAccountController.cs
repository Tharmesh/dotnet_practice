using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKING1.Repository;

namespace Banking
{
    public class BankAccountController
    {
        
        public BankAccountController() { }
       
        public void ReadAllAccount()
        {
            Console.Clear();
            for (int i = 0; i <Repository. bankAccounts.Count; i++)
            {
                Console.Write(Repository.bankAccounts[i].AccountNumber+" ");
                Console.Write(" "+Repository.bankAccounts[i].AccountName);
                Console.WriteLine(" "+Repository.bankAccounts[i].AccountBalance);
            }
            Console.ReadKey();
        }
        public void UpdateBankAccount()
        {
            Console.Clear();
            Console.Write("Enter Account Number : ");
            string acno=Console.ReadLine();
            BankAccount bankAccount = SearchAccount(acno);
            if (bankAccount!= null)
            {
                Console.WriteLine("What You Gonna Change ?\n1. Name\n2. Balance");
                int op = int.Parse(Console.ReadLine());
                if (op == 1)
                {                  
                    Console.Write("Enter New Name : ");
                    bankAccount.AccountName = Console.ReadLine();
                    Console.WriteLine("Name Changed Successfully !!");
                }
                if (op == 2)
                {
                    Console.Write("Enter New Balance : ");
                    bankAccount.AccountBalance = float.Parse(Console.ReadLine());
                    Console.WriteLine("Balance Changed Successfully !!");
                }
            }
            else
                Console.WriteLine("Invalid Account Number !!");
        }
        public void DeleteAllBankAccount()
        { 
            for (int i = 0;i<Repository.bankAccounts.Count;i++)
            {
                Repository.bankAccounts.Remove(Repository.bankAccounts[i]);
            }
        }
        public void DeleteSpecificBankAccount()
        {
            Console.Write("Enter Account Number : ");
            string acno = Console.ReadLine();
            BankAccount bank = SearchAccount(acno);
            if (bank != null)
            {
                Repository.bankAccounts.Remove(bank);
            }
        }
        public static BankAccount SearchAccount(string acno)
        { 
            for (int i = 0;i < Repository.bankAccounts.Count;i++)
            {
                if (acno == Repository.bankAccounts[i].AccountNumber)
                    return Repository.bankAccounts[i];
            }
            return null;
        }
    }
}
