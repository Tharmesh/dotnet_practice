using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BANKING1.Repository;

namespace Banking
{
    public class UPI_Transaction
    {
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public  void AddUpis()
        {
            Console.Clear();
            Console.Write("Enter Your Account Number : ");
            AccountNumber=Console.ReadLine();
            Console.Write("Enter Your Password : ");
            Password = Console.ReadLine();
        }
        public static void dummy()
        {
            Console.Clear();
            UPI_Transaction uPI = new UPI_Transaction();
            uPI.AddUpis();
            Repository.CreateUPI(uPI);
        }

    }
}
