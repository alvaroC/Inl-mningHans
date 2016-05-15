using System;
using System.Collections.Generic;

namespace BankActions
{
    //Klassen MaxiAccount representerar ett bankkonto som ärver från superklassen Account. Speciella egenskaper med detta konto är att det inte tillårer kredit,
    //det har en varierenda sparränta berående på ett tröskelvärde. Vidare tillåter kontot uttag associerad med en viss avgift
    class MaxAccount : Account
    {
        private int tröskelVärde = 20000, antalUttag = 0, uttagsAvgift = 20;
        private double interestRate;
        private double ränteSats1 = 0.01, ränteSats2 = 0.025;
        

        public override bool Withdraw(double amount)
        {
            if ((amount <= 0) || (balance - amount) < 0)
                return false;
            else
            {
                balance -= (amount + uttagsAvgift);
                antalUttag++;
                return true;
            }
        }
        public override double InterestRate()
        {
            if ((balance > 0) && (balance < tröskelVärde))
            {
                interestRate = balance * ränteSats1;
                balance += interestRate;
                return balance;
            }
            else
            { 
                interestRate = balance * ränteSats2;
                balance += interestRate;
                return balance;
            }
        }       

        public override string ToString()
        {
            return "Kontonr: " + Nr.ToString("G") + ", saldoMaxikonto: " + balance.ToString("C") + ", uttagsavgift: " + antalUttag*uttagsAvgift +  ", sparränta: " + ränteSats1*100 + "%" + ", maxiränta: " + ränteSats2*100 + "%";
        }
    }
}
