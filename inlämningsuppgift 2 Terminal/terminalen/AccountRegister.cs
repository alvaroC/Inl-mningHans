using System.Collections.Generic;

namespace BankActions
{
    /// <summary>
    /// Klassen AccountRegister ansvarar för att håller ordning på bankens alla konton.
    /// Det gör AccountRegister genom att lagra en referens till varje konto som
    /// förekommer i banken.
    /// </summary>
    class AccountRegister
    {
        private static AccountRegister instans = null;
        private List<Account> accountList = new List<Account>();   //Lista för referenser till konton
        private int theRegisterIndex;   //Index till ett konto, se metoderna First och Next
        
        /// <summary>
        /// Returnerar en referens till den enda instans av klassen AccountRegister
        /// som får förekomma.
        /// </summary>
        /// <returns></returns>
        public static AccountRegister GetTheAccountRegister()
        {
            if (instans == null)
                instans = new AccountRegister();

            return instans;
        }

        /// <summary>
        /// Konstructor för klass AccountRegister, utför inte något.
        /// Konstruktorn är privat för att det endast ska får förekomma ett
        /// kontoregister i programmet. Det kontoregistert kommer man åt
        /// genom att anropa klassmetoden GetTheAccountRegister.
        /// </summary>
        private AccountRegister()
        { }
        
        /// <summary>
        /// Sätter in referens från ett konto i registret
        /// </summary>
        /// <param name="theAccount">theAccount, en referens som ska sättas in i registret</param>
        public void Add(Account theAccount)
        {
            accountList.Add(theAccount);
        }
       
        /// <summary>
        /// Tar bort registrets referens till kontot
        /// </summary>
        /// <param name="theAccount">den referens som ska avlägsnas från registret</param>
        /// <returns>true om referensen har tagits bort, false om referensen inte hittades</returns>
        public bool Remove(int nr)
        {
            Account findAccount = Find(nr);
            if (findAccount != null)
            {
                accountList.Remove(findAccount);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Returnerar en referens till det konto vars nummer är lika med accountNr
        /// </summary>
        /// <param name="accountNr">accountNr det sökta kontots nummer</param>
        /// <returns>en referens till det sökta kontot, om referensen inte finns
        /// så returneras null</returns>
        public Account Find(int accountNr)
        {
            foreach(Account account in accountList)
            {
                if (account.Nr == accountNr)
                    return account;
            }
            
            return null;
        }

        //Räknar ränte belopp för samtlia konto
        public void AccountsInterestRate()
        {
            foreach (Account account in accountList)
            {
                account.InterestRate();
            }
        }

        /// <summary>
        /// Returnerar true om inga referenser till konton är registrerade
        /// </summary>
        /// <returns>true om registret är tomt, i annat fall false</returns>
        public bool IsEmpty()
        {
            return GetSize() < 1;
        }

        /// <summary>
        /// Returnerar antal referenser i registret
        /// </summary>
        /// <returns>antalet referenser till konton som finns i registret</returns>
        public int GetSize()
        {
            return accountList.Count;
        }

        /// <summary>
        /// Returnerar en referens till det första kontot i registet 
        /// </summary>
        /// <returns>den första referensen i registret, om registret
        /// är tomt returneras null</returns>
        public Account First()
        {
            if (IsEmpty())
                return null;
            else
            {
                theRegisterIndex = 0;
                return accountList[theRegisterIndex];
            }
        }

        /// <summary>
        /// Returnerar en referens till nästa konto i registet
        /// </summary>
        /// <returns>nästa referens i registret returneras, om inget fler
        /// referenser till konton finns så returneras null</returns>
        public Account Next()
        {
            theRegisterIndex++;

            if (theRegisterIndex < GetSize())
                return accountList[theRegisterIndex];
            else
                return null;
        }

        /// <summary>
        /// Kontrollerar om man har hamnat efter sista kontot vid en iteration
        /// över registrets konton
        /// </summary>
        /// <returns>true om man har hamnat efter sista kontot eller registret är tomt,
        /// i annat fall returneras false</returns>
        public bool IsAfterLast()
        {
            return IsEmpty() || theRegisterIndex >= GetSize();
        }
    }
}
