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
    class Program
    {
        private static StreamWriter receiptSave = new StreamWriter("Receipts.txt");
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
                            Console.WriteLine("\n\t\t\t[1] Change Product Names and/or Prices");
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
                                    Produces.ProductChange();
                                    break;
                                case 2:
                                    Receipts.ReceiptSearch();
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
                    Produces.finalProducts.Clear();
                    Purchase.grandTotal = 0;
                    Console.WriteLine("\tOops, something went wrong! Please Try again!!");
                    Console.WriteLine("\n\tPress Enter to continue");
                    Console.ReadLine();
                }
            }
        }
    }
}
