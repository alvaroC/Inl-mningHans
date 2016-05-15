using System;
using System.Collections.Generic;

namespace BankActions
{
    /// <summary>
    /// Klassen Account representerar ett konto.
    /// 
    /// Syftet med klassen är att den ska modifieras till en
    /// abstrakt basklass för de specifika kontoklasserna som
    /// ska implementeras enligt laborationsuppgiftens beskrivning.
    /// </summary>
    abstract class Account
    {
        private static int newNr = 1000;    //Nästa kontonummer som ska tilldelas ett konto
        private int nr;                     //Det här kontots, (this), kontonummer
        protected double balance = 0;           //Det här kontots, (this), saldo
        
        /// <summary>
        /// Tilldelar kontot ett unikt kontonummer
        /// </summary>
        public Account()
        {
            newNr++;
            nr = newNr;                        
        }

        /// <summary>
        /// Returnerar kontonumret
        /// </summary>
        public int Nr
        {
            get { return nr; }
        }
        

        /// <summary>
        /// Sätter in ett belopp på kontot
        /// </summary>
        /// <param name="amount">det belopp som ska sättas in</param>
        /// <returns>true om beloppet kunde sättas in, i annat fall false</returns>
        public bool Deposit(double amount)
        {
            if (amount <= 0)
                return false;

            balance += amount;            
            return true;
        }

        // Tar ut pengar från kontot. Virtuell metod som anpassar sig till olika situationer
        public virtual bool Withdraw(double amount)
        {
            if ((amount <= 0) || (balance - amount) < 0 )
                return false;
            else 
            {
                balance -= amount;
                return true;
            }            
        }

        //Alla subklaser måste implementera denna metod

        //Räknar sparränta under ett år
        public abstract double InterestRate();
       
        /// <summary>
        /// Sammanställer information om kontot
        /// </summary>
        /// <returns>information om kontot</returns>
        public virtual string ToString()
        {
            return "Kontonr: " + Nr.ToString("G") + ", saldo: " + balance.ToString("C") ;
        }      
        
        
    }
}
