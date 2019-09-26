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
        public void ProductChange(string productName, int productPrice)
        {
            this.ProductName = productName;
            this.ProductPrice = productPrice;
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
        
        public int ReceiptNo = 1000;
       
            public void ProductMain()
        {
            this.TotalPrice = this.ProductPrice * this.ProductAmount;
        }
        public string Receipt()
        {
            this.TotalPrice = this.ProductPrice * this.ProductAmount;

            string receiptMessage = String.Format("\n\n----- Item Code: {4} ----- \n{0} cost {1:C} a piece. \nSo {2} will cost you {3:C}. \nPress enter to advance", this.ProductName, this.ProductPrice, this.ProductAmount, this.TotalPrice, this.ProductID);

            return receiptMessage;
        }
        public static void ProduceInfo()
        {
            string input = "";
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
            
            bool keepGoing = true;
            while (keepGoing)
            {

                Console.Write("\n<ProductID>  <Quantity>\n");
                string answer = Console.ReadLine();

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
                            //Console.WriteLine("{0} {1:C} * {2}{3:C}  =  {4}", item.ProductName, item.ProductPrice, data2, item.ProductType, item.TotalPrice);
                            input = String.Format("{0} {1:C} * {2}{3:C}  =   {4:C}", item.ProductName, item.ProductPrice, data2, item.ProductType, item.TotalPrice);
                            
                            Purchase.grandTotal += item.TotalPrice;

                        }
                    }
                   
                }
                
                finalProducts.Add(input);
                Console.Clear();
                Purchase.TextToScreen();
            }   
        }
        public void TextOfMaths()
        {
            
        }
    }
}


