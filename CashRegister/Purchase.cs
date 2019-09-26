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

