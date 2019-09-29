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
    class Produces
    {

        public static List<Produces> Products = new List<Produces>();
        public void ProducPriceChange(string productName, int productPrice)
        {
            this.ProductPrice = productPrice;
        }
        public void ProductNameChange(string productName, int productPrice)
        {
            this.ProductName = productName;
        }
        public static void ProdFromText()
        {
            var readers = "..\\..\\Products.txt";
            List<string> line = File.ReadAllLines(readers).ToList();
            foreach (var reads in line)
            {
                string[] productSplit = reads.Split(' ');

                Produces newProduct = new Produces();

                newProduct.ProductName = productSplit[0];
                newProduct.ProductPrice = Double.Parse(productSplit[1]);
                newProduct.ProductType = productSplit[2];
                newProduct.ProductID = Int32.Parse(productSplit[3]);

                Products.Add(newProduct);
            }
        }
        public static List<string> finalProducts = new List<string>();
        public static string theProduct { get; set; }
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public double ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public double TotalPrice { get; set; }
        public string ProductType { get; set; }
        public string QuantityOrder { get; set; }       //oklart om den behövs

        public static int ReceiptNo = 1000;

        public static void ProduceInfo()
        {
            ProdFromText();
            string input = "";
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Write("\n<ProductID>  <Quantity>\n");
                string answer = Console.ReadLine();

                while (answer != "pay")
                {
                    var data = answer.Split(' ');
                    var data1 = int.Parse(data[0]);
                    var data2 = int.Parse(data[1]);

                    foreach (var item in Products)
                    {
                        if (item.ProductID == data1)
                        {
                            item.TotalPrice = item.ProductPrice * data2;
                            if (item.ProductID == data1)
                            {
                                input = String.Format("{0} {1:C} * {2}{3:C}  =   {4:C}", item.ProductName, item.ProductPrice, data2, item.ProductType, item.TotalPrice);
                                Purchase.grandTotal += item.TotalPrice;
                            }
                        }
                    }
                    finalProducts.Add(input);
                    Console.Clear();
                    Purchase.TextToScreen();
                    return;
                }
                if (answer == "pay")
                {
                    Purchase.TextTofile();
                    keepGoing = false;
                    return;
                }
            }
        }
        public static void ProductChanger()
        {
            ProdFromText();
            Console.WriteLine("Press [1] to change product name. Press [2] to change product price: ");
            int prodChangeMenu;
            while (!int.TryParse(Console.ReadLine(), out prodChangeMenu) || prodChangeMenu < 1 || prodChangeMenu > 2)
            {
                Console.Write("\n\tOops, something went wrong there! Try again!" + "\n\tPlease pick a number between 1-2: ");
            }
            switch (prodChangeMenu)
            {
                case 1:
                    Console.WriteLine("Enter a product ID to search for: ");
                    var searchID = Convert.ToInt32(Console.ReadLine());

                    foreach (var item in Products)
                    {
                        if (item.ProductID == searchID)
                        {
                            Console.WriteLine($"Product found. \nProduct: {item.ProductName}");
                            Console.WriteLine("Enter a new product name: ");
                            string newName = Console.ReadLine();
                            string changedName = item.ProductName.Replace(item.ProductName, newName);
                            //item.ProductName.Replace(item.ProductName, newName);
                            //File.Replace("..\\..\\Products.txt", changedName);
                        }
                    }

                    break;
                case 2:
                    break;
            }
        }

    }
}