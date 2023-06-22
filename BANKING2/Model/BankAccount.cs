using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class BankAccount
    {
        public BankAccount() { }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public float AccountBalance { get; set; }
        public void insertAccData()
        {

            Console.Write("Enter Account Number : ");
            AccountNumber = Console.ReadLine();
            Console.Write("Enter Customer Name : ");
            AccountName = Console.ReadLine();
            while(true)
            {
                Console.Write("Enter Minimum Balance : ");
                AccountBalance = float.Parse(Console.ReadLine());
                if (AccountBalance <= 500)
                {
                    Console.WriteLine("Sorry Your Amount Should be Above 500 !");
                    continue;
                }
                else
                    break;
            }
        }
        public static void openupi()
        {
            Console.WriteLine("Do You Want To Create Net Banking.\n1. YES\n2. NO\n");
            int cp = int.Parse(Console.ReadLine());
            if (cp == 1)
                UPI_Transaction.dummy();
            Console.WriteLine("Thank You " + (char)(2));
        }
       
    }
}
