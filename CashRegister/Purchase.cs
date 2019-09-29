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

        public static string reading = "";

        public static double grandTotal = 0;
        public static double Discount = (grandTotal * 0.02);
        public static double Discount2 = (grandTotal * 0.03);
        public static double TotalDiscount = grandTotal - Discount;
        public static double TotalDiscount2 = grandTotal - Discount2;

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

            return;
        }
        public static void TextTofile()
        {
            var datenow = DateTime.Now.ToString("yyyyMMdd");
            string path = ($"..\\..\\Receipt_{datenow}" + ".txt");
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            if (File.Exists(path))
            {
                using (var receiptToFile = File.AppendText(path))
                {
                    receiptToFile.WriteLine(Produces.ReceiptNo);
                    receiptToFile.WriteLine(datenow);
                    foreach (var item in Produces.finalProducts)
                    {
                        receiptToFile.WriteLine(item);
                    }
                    if (grandTotal < 1000)
                    {
                        receiptToFile.WriteLine($"Total: {grandTotal}");
                    }
                    if (grandTotal > 1000)
                    {
                        receiptToFile.WriteLine($"Product total: {grandTotal}");
                        receiptToFile.WriteLine($"Discount: {Discount}");
                        receiptToFile.WriteLine($"Grand total: {TotalDiscount}");
                    }
                    if (grandTotal > 2000)
                    {
                        receiptToFile.WriteLine($"Product total: {grandTotal}");
                        receiptToFile.WriteLine($"Discount: {Discount2}");
                        receiptToFile.WriteLine($"Grand total: {TotalDiscount2}");
                    }
                }
            }
            return;
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