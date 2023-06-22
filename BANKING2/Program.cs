using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKING1.Repository;

namespace Banking
{
    public class Program
    {
        static void Main(string[] args)
        {
            do
            {
                BankAccount account = new BankAccount();
                AccountTransaction transaction = new AccountTransaction();
                BankAccountController controller = new BankAccountController();
                transactionController controller1 = new transactionController();
                UPI_Transaction upi = new UPI_Transaction();
                Console.WriteLine("1. Create Bank Account ");
                Console.WriteLine("2. Read All Bank Account");
                Console.WriteLine("3. Update Bank Account ");
                Console.WriteLine("4. Delete Bank All Account ");
                Console.WriteLine("5. Delete Specific Bank Account");
                Console.WriteLine("6. Make Transaction ");
                Console.WriteLine("7. Open Net Banking");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Enter Your Option : ");
                int op=int.Parse(Console.ReadLine());
                if (op == 1)
                {
                    account.insertAccData();
                    Repository.addAccount(account);
                    transaction.insertAccData(account);
                    Repository.addAccount(transaction);
                }
                if (op == 2)
                {
                    controller.ReadAllAccount();
                }
                if (op == 3)
                { 
                    controller.UpdateBankAccount();
                }
                if (op == 4)
                { 
                    controller.DeleteAllBankAccount();
                }
                if (op == 5)
                { 
                    controller.DeleteSpecificBankAccount();
                }
                if (op == 6)
                {
                    controller1.TransactionType();
                }
                if (op == 7)
                {
                    BankAccount.openupi();
                }
                if (op == 8)
                    break;
                Console.ReadKey();
                Console.Clear();
            }
            while (true);
        }
    }
}
