using System;
using System.Collections.Generic;
using BankActions;

namespace UserInterface
{
    /// <summary>
    /// Klass Terminal är applikationens gränssnitt mot användaren.
    /// 
    /// I det här fallet rör det sig om ett radorienterat
    /// användargränssnitt som är avsett att köras i
    /// operativsystemets kommandotolk.
    /// 
    /// Till klassen är associerat dels ett objekt av klassen Transaction, theBank,
    /// och dels en ett objekt av klassen Dialoge, theDialoge.
    /// 
    /// Terminalen delegerar alla banktransaktioner till theBank. theDialoge använder
    /// terminalen för kommunikation med programmets användare.
    /// </summary>
    public class Terminal
    {

        private Transaction theBank;    //Refererar till ett objekt av typen Transaction
        private Dialogue theDialogue;   //Refererar till ett objekt av typen Dialoge
        private List<Account> accounts = new List<Account>();      

        /// <summary>
        /// Konstruktor för klassen Terminal.
        /// </summary>
        public Terminal()
        {
            theDialogue = new Dialogue();
            theBank = new Transaction(this);
        }

        /// <summary>
        /// Läser in ett meddelande som ska visas i terminalen
        /// </summary>
        /// <param name="message">Det meddelande som ska visas</param>
        public void SetMessage(string message)
        {
            theDialogue.SetMessage(message);
        }

        /// <summary>
        /// Kör användargränssnittet, visar meny-alternativen och 
        /// låter användaren välja ett kommando och hanterar detta val
        /// </summary>
        public void RunMenu()
        {
            int command = 0;
            
            do
            {
		        uppdate();

                command = theDialogue.ReadInt("=>: ");
            
                switch (command)
                {            
                    case 0:     //AVSLUTA
                    break;
                
                    case 1:     //SKAPA
			        {
                        int accountType = theDialogue.ReadInt("Välj typ av konto, (1 <-Sparkonto, 2 <-Maxikonto, 3 <-Lönekonto)=>: ");
                        theBank.NewAccount(accountType);
                        break;
			        }
                    
                    case 2:     //AKTIVERA
			        {
                        int accountNumber = theDialogue.ReadInt("Kontonummer: ");
                        theBank.ActivateAccount(accountNumber);
                        break;
			        }
                    
                    case 3:     //INSÄTTNING
			        {
                        if (theBank.HasActiveAccount())
                        {
                            double amount = theDialogue.ReadDouble("Belopp: ");
                            theBank.Deposit(amount);
                        }
                        break;
			        }
                    
                    case 4:    //UTTAG
			        {
                         if (theBank.HasActiveAccount())
                         {
                              double amount = theDialogue.ReadDouble("Belopp: ");
                              theBank.Withdraw(amount);
                         }
                         break;
                    }

                    case 5:    //RADERA
			        {
                            if (theBank.HasActiveAccount())
                            {
                                int nr = theDialogue.ReadInt("Ange konto nummer: ");
                                theBank.Remove(nr);
                                theBank.DeActivateAccount();
                            }   
                        break;                   
			        }
                    
                    case 6:    //INAKTIVERA
			        {
                        if (theBank.HasActiveAccount())
                            theBank.DeActivateAccount();
                        break;
			        }

                    case 7:    //BERÄKNA RÄNTA 
			        {
                       theDialogue.SetMessage("Räntebelopp under år");
                       theBank.ComputeInterestRate();                                                                        
                       break;      
			        }

			        default:
			        {
                        theDialogue.SetMessage("Fel kommando, välj ett kommando i från menyn.");
                        break;
			        }

		        }        
            }while (command != 0);
            
            Console.WriteLine("Programmet är avslutat");
        }


        /// <summary>
        /// Visar en meny med olika kommandon för användaren
        /// </summary>
        private void showMenu()
        {   
            Console.WriteLine("\n\nTERMINALEN");
            drawLine('_', 80);

            Console.WriteLine("0 <- Avsluta programmet");
            Console.WriteLine("1 <- Skapa ett nytt konto");
            Console.WriteLine("2 <- Aktivera ett konto");

            if (theBank.HasActiveAccount())
            {
                Console.WriteLine("3 <- Sätt in pengar på det aktiva kontot");
                Console.WriteLine("4 <- Ta ut pengar från det aktiva kontot");
                Console.WriteLine("5 <- Radera det aktiva kontot");
                Console.WriteLine("6 <- Inaktivera det aktiva kontot");            
            }

            Console.WriteLine("7 <- Räkna ränta på samtliga konton");
        }


        /// <summary>
        /// Läser aktuella värden från bankverksamhetens aktiva konto
        /// och visar den informationen för användaren
        /// </summary>
        private void uppdate()
        {
            Console.Clear();		//Rensar kommandotolken

	        showMenu();
	        drawLine('-', 80);
            theDialogue.ShowMessage();

            if (theBank.HasActiveAccount())
            {
                drawLine(' ', 0);	//Ny rad
                showAccountInfo();
            }       
              
            drawLine('_', 80);
        }
        
        /// <summary>
        /// Visar information om ett konto för användaren 
        /// </summary>
        private void showAccountInfo()
        {
            string info = theBank.AccountInfo();
            Console.WriteLine("Aktivt konto: " + info);
        }      

        /// <summary>
        /// Ritar ett horisontell linje.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="size"></param>
        private void drawLine(char symbol, int size)
        {
            for (int i=0; i<size; i++)
                Console.Write(symbol);

            Console.WriteLine();
        }
    }
}