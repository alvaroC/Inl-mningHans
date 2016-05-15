namespace BankActions
{
    /// <summary>
    /// Klassen AccountFactory skapar nya konton
    /// </summary>
    class AccountFactory
    {
        /// <summary>
        /// Skapar ett konto av önskad typ
        /// </summary>
        /// <param name="accountType">nummer som representerar den typ av konto som ska skapas</param>
        /// <returns>en referens till det skapade kontot</returns>
        public static Account CreateAccount(int accountType)
        {
            switch (accountType)
            {
                case 1:
                    return new SaveAccount();
                    break;
                case 2:
                    return new MaxAccount();
                    break;
                case 3:
                    return new SalaryAccount();
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
