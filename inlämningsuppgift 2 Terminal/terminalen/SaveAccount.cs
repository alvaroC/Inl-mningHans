using System;
using System.Collections.Generic;

namespace BankActions
{
    //Klassen SaveAccount representerar ett bankkonto som ärver från superklassen Account.Speciella egenskaper med detta konto är att det har en specifik 
    //sparränta och det tillårer ingen kredit
    class SaveAccount : Account
    {
        private double interestRate;
        private double ränteSats = 0.012;
       
        public override bool Withdraw(double amount)
        {
            return false;
        }
        public override double InterestRate()
        {
            interestRate = balance * ränteSats;
            balance += interestRate;
            return balance;           
        }       

        public override string ToString()
        {
            return "Kontonr: " + Nr.ToString("G") + ", saldoSparkonto: " + balance.ToString("C") + ", sparränta: " + ränteSats*100 + " % ";           
        }
    }
}
