using System;
using System.Collections.Generic;


namespace Bank
{




    public class Program // Main Class
    {
        static void Main(string[] args)
        {
            List<Users> listUserss = new List<Users>()
        {
                  new FixedDeposit("Naveenkumar M",5490383,1000),
                  new NormalDeposit("Sathishkumar M",88903839,1000)
        };

            foreach (var Userss in listUserss)
            {
                Userss.Bankbalance();
                Userss.printDetails();
                Userss.interestamount();  
            }
        }
    }

    public abstract class Users // Abstract class / (Base Class)
    {
        public Users(string userName,int AcNumber, int DepositPerMonth)  //constructor with parameters
        {
            this.userName = userName;
            this.AcNumber = AcNumber;
            this.DepositPerMonth = DepositPerMonth;

        }
        private string userName { get; set; } //properties / Encapsulation
        private int AcNumber { get; set; }
        private decimal DepositPerMonth { get; set; }

        private const decimal interest = 5.0m;

        protected decimal BankBalance;

        protected decimal BankBalanceWithInterst;

        public void printDetails()
        {
            Console.WriteLine($"User Name :  {this.userName} , AC No : {this.AcNumber} , BankBalance in 1-year is :  {this.BankBalance} ");
        }
        public void Bankbalance()
        {
            BankBalance = DepositPerMonth * 12;
        }
        public virtual void interestamount() // Polymorphism and Overriding Methods ( use Virtual to the Method inside Base )
        {
            BankBalanceWithInterst = this.BankBalance + (BankBalance * interest * 1 / 100);
            Console.WriteLine($"interestAmount in 1 year : {BankBalance * interest * 1/100} , Bank Balance with Interst amount is : {this.BankBalanceWithInterst}");
            Console.WriteLine();
       }   
    }
    public class FixedDeposit: Users // Inheritance  (child class)
    {
        public FixedDeposit(string userName, int AcNumber, int DepositPerMonth) : base( userName, AcNumber, DepositPerMonth)
        {

        }
        private const decimal interest = 10.0m;

        public override void interestamount() // Polymorphism and Overriding Methods ( override keyword for derived class method )
        {
            BankBalanceWithInterst = this.BankBalance + (BankBalance * interest * 1 / 100);
            Console.WriteLine($"interestAmount in 1 year : {BankBalance * interest * 1 / 100} , Bank Balance with Interst amount is : {this.BankBalanceWithInterst}");
            Console.WriteLine();
        }
    }
    public class NormalDeposit : Users
    {
        public NormalDeposit(string userName, int AcNumber, int DepositPerMonth) : base(userName, AcNumber, DepositPerMonth)
        {

        }
    }
}
