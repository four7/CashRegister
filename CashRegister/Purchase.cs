using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CashRegister
{
    class Purchase
    {
<<<<<<< Updated upstream
=======
        public static string reading = "";
>>>>>>> Stashed changes
        public static double grandTotal = 0;
        
        public static void TextToScreen()
        {
            
            var dateReceipt = DateTime.Now;

            Console.WriteLine("\n\t\t\t\t***CASH REGISTER***");
            Console.WriteLine("\nREGISTER");
            Console.WriteLine("RECEIPT  " + dateReceipt);
            Console.WriteLine("Item   Price  Quantity   Total\n\n");
            TheProducts();
            Console.WriteLine("\nTOTAL:                 {0:C}", grandTotal);
            Produces.ProduceInfo();
<<<<<<< Updated upstream
              
=======
            reading = Console.ReadLine();
        }
        public static void TextTofile()
        {
            DateTime datenow = DateTime.Now;
            datenow.ToString("yyyyMMdd");
            string path = ($"..\\..\\Receipt_{datenow}");
            if (File.Exists(path))
            {
                File.AppendAllText(path, reading);
            }
            using (StreamWriter receiptToFile = new StreamWriter(path))
            {
                File.WriteAllText(path, reading);
            }
>>>>>>> Stashed changes
        }
        public static void TheProducts()
        {
            foreach (string item in Produces.finalProducts)
            {
                Console.WriteLine(item); 
            }       
        }
        public static void PurchaseMain()
        {
            Console.Clear();
            TextToScreen();
        }
    }
}

