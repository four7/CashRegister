using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister   
{
    class Program
    {
        private static StreamWriter receiptSave = new StreamWriter("Receipts.txt");
        private static double grandTotal = 0;
        static void Main(string[] args)
        {
            receiptSave.WriteLine("\nYour Receipt: \n\n");
            receiptSave.WriteLine("Item   Quantity  Price   Total\n\n");
            bool active = true;
            while (active)
            {
                try
                {
                    Console.WriteLine("\n\t\t\t****Welcome to your online store****");
                    Console.WriteLine("\n\t\t\t\t***CASH REGISTER***");
                    Console.WriteLine("\n\t\t\t[1] New Customer");
                    Console.WriteLine("\t\t\t[2] Admin Login");
                    Console.WriteLine("\t\t\t[3] Quit");
                    Console.Write("\n\t\t\tPlease choose an option between 1-3:");

                    int menuOption;
                    while (!int.TryParse(Console.ReadLine(), out menuOption) || menuOption < 1 || menuOption > 3)
                    {
                        Console.Write("\n\tOops, something went wrong there! Try again!" + "\n\tPlease pick a number between 1-3: ");
                    }
                    switch (menuOption)
                    {
                        case 1:
                            Purchase.PurchaseMain();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("\n\t\t\t\t****ADMIN MENU****");
                            Console.WriteLine("\n\t\t\t[1] Change Prices");
                            Console.WriteLine("\t\t\t[2] Search Receipts");
                            Console.WriteLine("\t\t\t[3] Campaign Prices");
                            Console.WriteLine("\t\t\t[4] Return to main menu");
                            Console.Write("\n\t\t\tPlease choose an option between 1-4:");

                            int adminMenu;
                            while (!int.TryParse(Console.ReadLine(), out adminMenu) || adminMenu < 1 || adminMenu > 4)
                            {
                                Console.Write("\n\tOops, something went wrong there! Try again!" + "\n\tPlease pick a number between 1-4: ");
                            }
                            switch (adminMenu)
                            {
                                case 1:

                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                            }
                            break;
                        case 3:
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\tOops, something went wrong! Please Try again!!");
                    Console.WriteLine("\n\tPress Enter to continue");
                    Console.ReadLine();
                }
            }
        }
        public static void RegisterRunning(Produces products)
        {
            receiptSave.WriteLine(ReceiptPrintText(products));
            ReceiptToText();
            grandTotal += products.TotalPrice;
        }
        public static void ReceiptToText()
        {
            receiptSave.WriteLine("\n-----------------------------------------");
            receiptSave.Close();

            Console.Clear();

            StreamReader readReceipt = new StreamReader("Receipts.txt");
            string textLines = "";

            while ((textLines = readReceipt.ReadLine()) != null)
            {
                Console.WriteLine(textLines);
            }
            Console.WriteLine("\nGRAND TOTAL:                       {0:C}", grandTotal);
            Console.ReadLine();
        }
        private static string ReceiptPrintText(Produces products)
        {
            string allUserChoices = String.Format("{0} --- {1} --- {2:C} --- {3:C}", products.ProductName, products.ProductAmount, products.ProductPrice, products.TotalPrice);
            return allUserChoices;
        }
        public void printReceipt(Produces products)
        {
            Console.WriteLine(products.Receipt());
        }
    }
}
