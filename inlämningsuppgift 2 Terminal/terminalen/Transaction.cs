
using UserInterface;

namespace BankActions
{
    /// <summary>
    /// Klassen Transaction ansvarar för bankens transaktioner.
    /// 
    /// Ett objekt av klassen Transaction har till hjälp ett objekt
    /// av typen AccountRegister.
    /// 
    /// För att hålla rätt på vilket konto
    /// som är aktivt för insättningar och uttag så finns en datamedlem
    /// activAccount.
    /// 
    /// Dessutom finns en datamedlem, terminal, som referar
    /// till banksystemets terminal. Med hjälp av referensen, terminal,
    /// så kan Transaction visa meddelanden för användaren
    /// av programmet.
    /// </summary>
    public class Transaction
    {
        private Terminal terminal;
        private Account activeAccount;
        private AccountRegister theRegister = AccountRegister.GetTheAccountRegister();


        /// <summary>
        /// Konstruktor för klassen Transaktion.
        /// Skapar en association till bankssystemets terminal.
        /// Ser till att inget konto är aktivt.
        /// </summary>
        public Transaction(Terminal theTerminal)
        {
            terminal = theTerminal;
            activeAccount = null;
        }
        
        /// <summary>
        /// Skapar ett konto och sätter det till aktivt konto
        /// Registrerar kontot till kontoregistret och
        /// uppdaterar informationen i terminalen
        /// </summary>
        /// <param name="type">type, den typ av konto som ska skapas</param>
        public void NewAccount(int type)
        {
            activeAccount = AccountFactory.CreateAccount(type);
            theRegister.Add(activeAccount);
            terminal.SetMessage("Ett nytt konto har skapats.");            
        }

        //Räknar ränte belopp för samtlia konto
        public void ComputeInterestRate()
        {
            theRegister.AccountsInterestRate();
        }            

        //Ta bort kontot
        public void Remove(int nr)
        {
            if (theRegister.Remove(nr))
                terminal.SetMessage("Kontot har tagists bort.");
            else
                terminal.SetMessage("Det finns inte detta konto");
        } 

        /// <summary>
        /// Aktiverar ett konto så att det blir möjligt att utföra
        /// olika transaktioner på det och uppdaterar terminalen
        /// med information om det aktiva kontot
        /// </summary>
        /// <param name="accountNr">numret på det konto som ska aktiveras</param>
        public void ActivateAccount(int accountNr)
        {
            activeAccount = theRegister.Find(accountNr);

            if (activeAccount == null)
                terminal.SetMessage("Det finns inget konto med det numret");
        }


        /// <summary>
        /// Undersöker om något konto är aktivt
        /// </summary>
        /// <returns>true om ett konto är aktivt, i annat fall false</returns>
        public bool HasActiveAccount()
        {
            return activeAccount != null; 
        }


        /// <summary>
        /// Ger information om det aktuella kontot
        /// </summary>
        /// <returns>Om ett konto är aktivt så returneras information
        /// om kontot, i annat fall returneras ett felmeddelande</returns>
        public string AccountInfo()
        {
            if (HasActiveAccount())
                return activeAccount.ToString();
            else
                return "Inget konto är aktivt.";
        }


        /// <summary>
        /// Sätter in ett belopp på aktivt konto. Om beloppet inte kunde
        /// sättas in så kommer ett meddelande om detta att visas i terminalen
        /// </summary>
        /// <param name="amount">Det belopp som ska sättas in på det aktiva kontot</param>
        public void Deposit(double amount)
        {
            if (activeAccount.Deposit(amount) == false)
                terminal.SetMessage("Beloppet kunde ej sättas in.");
	        else
                terminal.SetMessage("Beloppet är insatt.");
        }

        // Ta ut ett belopp på aktivt konto. Om beloppet överstiger saldot
        /// kommer ett meddelande om detta att visas i terminalen
        /// </summary>
        /// <param name="amount">Det belopp som ska sättas in på det aktiva kontot</param>
        public void Withdraw(double amount)
        {
            if (activeAccount.Withdraw(amount) == false)
                terminal.SetMessage("Det saknas täckning eller du har angivit fle belopp.");
            else
                terminal.SetMessage("Ta ut pengarna");
        }
        public double InterestRate()
        {
            double interestRate;
            interestRate =  activeAccount.InterestRate();
            return interestRate;
        }        

        /// <summary>
        /// Inaktiverar aktivt konto, så att inga andra transaktioner än ränteberäkning
        /// går att utföra
        /// </summary>
        public void DeActivateAccount()
        {
            activeAccount = null;
        }
    }
}
