using System;
using System.Collections.Generic;

namespace BankActions
{
    //Klassen SalaryAccount representerar ett bankkonto som ärver från superklassen Account. Speciella egenskaper med detta konto är att det tillåter kredit
    //till ett visst belopp. Kontot har både kreditränta och sparränta 
    class SalaryAccount : Account
    {
        private double creditInterestRate;
        private double ränteSats = 0.001, creditRänteSats = 0.089;
        private int creditLimit = -10000;
               
        public double CreditInterestRate()
        {
            if ((balance < 0) && (balance < creditLimit))
            {  
                creditInterestRate = balance * creditInterestRate;
                return creditInterestRate;
            }
            else
            {
                creditInterestRate = 0;
                return creditInterestRate;
            }
        }
        public override bool Withdraw(double amount)
        {
            if ((amount <= 0) || (balance - amount) < creditLimit)
                return false;
            else
            {
                balance -= amount;
                return true;
            }
        }
        public override double InterestRate()
        {
            double interestRate;
            if (balance > 0)
            {
                 interestRate = balance * ränteSats;
                balance += interestRate;
                 return balance;
            }
            else
                return balance;
          }
        

        public override string ToString()
        {
            return "Kontonr: " + Nr.ToString("G") + ", saldo Lönekonto: " + balance.ToString("C") + ", sparränta: " + ränteSats*100 + "%" + ", kreditränta: " + creditInterestRate*100 + "%";
        }
    }
}
