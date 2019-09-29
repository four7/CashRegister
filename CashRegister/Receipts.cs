using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class Receipts
    {
        public static List<Receipts> SearchReceipts = new List<Receipts>();
        public int ProductSearchID { get; set; }
        public int ProductSearchTotal { get; set; }
        public string ProductSearchReceipt { get; set; }
        public static void ReceiptSearch()
        {
            Console.Clear();
            Console.WriteLine("Enter a date to search for (e.g: 20190923) ");
            string searchinput = Console.ReadLine();

            var searchReader = "..\\..\\Receipt_" + searchinput + ".txt";
            if (File.Exists(searchReader))
            {
                List<string> searchLines = File.ReadAllLines(searchReader).ToList();
                foreach (var reads in searchLines)
                {
                    string[] searchSplit = reads.Split('-');

                    Receipts finalSearchSplit = new Receipts();

                    finalSearchSplit.ProductSearchID = Int32.Parse(searchSplit[0]);

                    finalSearchSplit.ProductSearchReceipt = searchSplit[1];
                    finalSearchSplit.ProductSearchTotal = Int32.Parse(searchSplit[2]);
                    //finalSearchSplit.ProductID = Int32.Parse(searchSplit[3]);

                    SearchReceipts.Add(finalSearchSplit);
                }
                foreach (var item in SearchReceipts)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your search does not exist.");
                return;
            }
        }
    }
}