using UserInterface;

namespace BankTerminal
{
    /// <summary>
    /// Klassen Program skapar en bankterminal som körs i kommandotolken
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main skapar en ett objekt av klassen Terminal
        /// </summary>
        public static void Main()
        {
            Terminal theTerminal = new Terminal();
            theTerminal.RunMenu();
        }
    }
}
