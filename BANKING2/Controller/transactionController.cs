using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BANKING1.Repository;

namespace Banking
{
   public class transactionController
    { 
        public static Repository repository = new Repository();
        public void ReadAllAccount()
        {
            Console.Clear();
            Console.WriteLine("Here the All Transaction Account Details");
            for (int i = 0; i <repository.AccountCount(); i++)
            {
                Console.WriteLine((repository.accountposition(i)).AccNo + "  " +(repository.accountposition(i)).AccName + "  " +repository. accountposition(i).AccBal);
            }
        }
        public void TransactionType()
        {
            Console.Clear();
            do
            {
                Console.Clear();
                Console.WriteLine("             What Type Of Transaction You Would Like To Do ?");
                Console.WriteLine("             \t\t\t1. Cash Deposit\n\t\t\t\t2. Withdrawal\n\t\t\t\t3.UPI Transaction\n\t\t\t\t4. Quit");
                Console.Write("\n               Enter Your Option : ");
                int op = int.Parse(Console.ReadLine());
                if (op == 1)
                    CashDeposit();
                else if (op == 2)
                    Withdrawal();
                else if (op == 3)
                    UPITransaction();
                else if (op == 4)
                    break;
            }
            while (true);
            
        }
        public void CashDeposit()
        {
            Console.Clear();
            Console.WriteLine("You Have Choosen Cash Deposit !");
            Console.Write("Enter Your Account Number : ");
            string acno = Console.ReadLine();
            AccountTransaction accountTransaction = transactionController.SearchAccount(acno);
            BankAccount account = SearchBankAccount(acno);
            if (accountTransaction != null)
            {
                Console.Write("Enter Deposit Amount : ");
                accountTransaction.AccBal = float.Parse(Console.ReadLine()) + accountTransaction.AccBal;
                if (account!=null)
                { 
                        account.AccountBalance = accountTransaction.AccBal;
                        Console.WriteLine("Your Amount Deposited Successfully !!");
                    }
            }
            else
            { Console.WriteLine("Please Check Your Account Number !!"); }
            
        }
        public void Withdrawal()
        {
            Console.Clear();
            Console.WriteLine("You Have Choosen Cash WithDrawal !");
            Console.Write("Enter Your Account Number : ");
            string acno = Console.ReadLine();
            
            AccountTransaction a = transactionController.SearchAccount(acno);
            BankAccount bankAccount = SearchBankAccount(acno);
            if ( a!= null)
            {
                while (true)
                {
                    Console.Clear();
                    Console.Write("Enter Withdrawal Amount : ");
                    float wam = float.Parse(Console.ReadLine());
                    if (wam <= a.AccBal)
                    { 
                        a.AccBal = a.AccBal - wam;
                        bankAccount.AccountBalance =a.AccBal;
                        Console.WriteLine("Your Amount Widrawn Successfully !!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Balance !!");
                        Console.ReadKey();
                        continue;
                    }
                }

            }
            else
            { Console.WriteLine("Please Check Your Account Number !!"); }
            
        }

        public void UPITransaction()
        {
            Console.Clear();
            Console.WriteLine("You Have Choosen UPI Transcation !!");
            Console.Write("Enter From Account Number : ");
            string acno = Console.ReadLine();
            if (transactionController.SearchAccount(acno) != null)
            {
                Console.Write("Enter Your Password : ");
                string pass = Console.ReadLine();

                if (transactionController.SearchUPIAcNo(acno) != null && transactionController.SearchUPIPass(pass) != null)
                {
                    Console.WriteLine("You Have Logged In Successfully !");
                    Console.Write("Enter TO Account Number : ");
                    string toacno = Console.ReadLine();
                    if (transactionController.SearchAccount(toacno) != null)
                    {
                        if (transactionController.SearchUPIAcNo(toacno) != null)
                        {
                            Console.Write(" Now You Both Can Make Transaction !\n");
                            Console.Write("Enter your Amount : ");
                            float amo = float.Parse(Console.ReadLine());
                            transferAmount(acno, toacno, amo);
                        }
                        else
                            Console.WriteLine("Your Opponent Does not Created a UPI Account !!");
                    }
                    else
                        Console.WriteLine("Your Account Number : " + toacno + " is Invalid !!");
                }
                else
                {
                    if (transactionController.SearchUPIAcNo(acno) != null && transactionController.SearchUPIPass(pass) == null)
                        Console.WriteLine("Incorrect Password !!");
                    else
                    {
                        Console.WriteLine("Sorry You Don't Have A Net Banking !\nWould You Like To Create it !");
                        Console.WriteLine("1. To Create\n2. To Quit");
                        int cr = int.Parse(Console.ReadLine());
                        if (cr == 1)
                        {
                            UPI_Transaction.dummy();
                        }
                    }
                }
            }
            else
            {Console.WriteLine(acno + " This Account Does not Contain Bank Account !!");}
            Console.ReadKey();
            
        }
        public void transferAmount(string acno, string toacno, float amo)
        {
            Console.Clear();
            AccountTransaction account = SearchAccount(acno);
            AccountTransaction account1 = SearchAccount(toacno);
            if (account != null && account1 != null)
                if (account.AccBal >= amo)
                {
                    account.AccBal -= amo;
                    account1.AccBal += amo;
                    BankAccount bankAccount = SearchBankAccount(acno);
                    BankAccount bankAccount1 = SearchBankAccount(toacno);
                    bankAccount.AccountBalance=account.AccBal;
                    bankAccount1.AccountBalance = account1.AccBal;
                    Console.WriteLine("Amount Transfered Successfully !!");
                }
                else
                    Console.WriteLine("InSufficient Amount in Your Account !");
           
        }
        
        public static AccountTransaction SearchAccount(string accno)
        {
            for (int s = 0; s < repository.AccountCount(); s++)
            {
                if (accno == (repository.accountposition(s)).AccNo)
                {
                    return repository.accountposition(s);
                }
            }
            return null;
        }
        public static UPI_Transaction SearchUPIAcNo(string accno)
        {
            for (int i = 0; i < repository.UPIAccountCount(); i++)
            {
                if (accno == repository.upiposition(i).AccountNumber)
                    return repository.upiposition(i);
            }
            return null;
        }
        public static UPI_Transaction SearchUPIPass(string pass)
        {
            for (int i = 0; i < repository.UPIAccountCount(); i++)
            {
                if (pass == repository.upiposition(i).Password)
                    return repository.upiposition(i);
            }
            return null;
        }
        public static BankAccount SearchBankAccount(string accno)
        {
            for (int s = 0; s <Repository. bankAccounts.Count; s++)
            {
                if (accno == Repository.bankAccounts[s].AccountNumber)
                {
                    return Repository.bankAccounts[s];
                }
            }
            return null;
        }
    }
}
