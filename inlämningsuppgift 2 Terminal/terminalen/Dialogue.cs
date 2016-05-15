using System;

namespace UserInterface
{
    /// <summary>
    /// Klass Dialogue ansvarar för generella dialoger mellan användaren och programmet
    /// </summary>
    class Dialogue
    {
        private string message; //Det meddelande som ska visas för användaren, se
                                //Metoderna SetMessage och ShowMessage


        /// <summary>
        /// Konstruktorn gör inget
        /// </summary>
        public Dialogue()
        {
        }


        /// <summary>
        /// Visar ett meddelande för användaren 
        /// </summary>
        public void ShowMessage()
        {
            Console.WriteLine("Meddelande: " + message);
            message = "";
        }


        /// <summary>
        /// Läser in ett meddelande som ska visas med hjälp av showMessage
        /// </summary>
        /// <param name="text">det meddelande som ska visas</param>
        public void SetMessage(string text)
        {
            message = text;
        }


        /// <summary>
        /// Skriver ut en fråga i kommandotolken och returnerar svaret
        /// i form av ett teckensträng.
        /// </summary>
        /// <param name="question">den fråga som ska visas</param>
        /// <returns>den teckensträng som användaren svarar med</returns>
        public string ReadString(string question)
        {
            string answer;
            Console.Write(question);
            answer = Console.ReadLine();
            return answer;
        }


        /// <summary>
        /// Skriver ut en fråga i kommandotolken och returnerar svaret
        /// i form av ett heltal. Om användaren svarar med något annat
        /// än ett heltal så repeteras frågan.
        /// </summary>
        /// <param name="question">den fråga som ska visas</param>
        /// <returns>det heltal som användaren svarar med</returns>
        public int ReadInt(string question)
        {
	        int heltal;
            bool ok;

	        do
	        {
                string answer = ReadString(question);
                ok = int.TryParse(answer, out heltal);
	        } while (!ok);

	        return heltal;
        }


        /// <summary>
        /// Skriver ut en fråga i kommandotolken och returnerar svaret
        /// i form av ett heltal. Om användaren svarar med något annat
        /// än ett heltal så repeteras frågan.
        /// </summary>
        /// <param name="question">den fråga som ska visas</param>
        /// <returns>det heltal som användaren svarar med</returns>
        public double ReadDouble(string question)
        {
            double flyttal;
            bool ok;

            do
            {
                string answer = ReadString(question);
                ok = double.TryParse(answer, out flyttal);
            } while (!ok);

            return flyttal;
        }
    }
}
