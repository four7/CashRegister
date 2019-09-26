using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Purchase
    {
        
        public static void TextToScreen()
        {
            var dateReceipt = DateTime.Now;

            Console.WriteLine("\n\t\t\t\t***CASH REGISTER***");
            Console.WriteLine("\nREGISTER");
            Console.WriteLine("RECEIPT  " + dateReceipt);

 
        }
        public static void TheProducts()
        {
            foreach (var item in Produces.finalProducts)
            {
                Console.WriteLine(item);
            }
            
        }
        public static void PurchaseMain()
        {

            Console.Clear();

            TextToScreen();
            Produces.ProduceInfo();

            
        }

    }


}

