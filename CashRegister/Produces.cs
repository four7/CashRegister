using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        //public List<Produces> GetProductsFile { get; set; }

        public int ReceiptNo = 1000;
        //public List<Produces> ProductDate()
        //{
        //    //var productsFile = new List<Produces>();

        //    var readers = @"C:\Users\ipell\source\repos\CashRegister\CashRegister\Products.txt";
        //    List<string> line = File.ReadAllLines(readers).ToList();
        //    //List<Produces> productObj = new List<Produces>();
        //    foreach (var reads in line)
        //    {
        //        string[] productSplit = reads.Split(' ');

        //        Produces newProduct = new Produces
        //        {
        //            ProductName = productSplit[0],
        //            ProductPrice = Convert.ToDouble(productSplit[1]),
        //            ProductType = productSplit[2],
        //            ProductID = Convert.ToInt32(productSplit[3]),
        //        };

        //        Products.Add(newProduct);


        //    }

            //    return Products;
            //}
            public void ProductMain()
        {

            //var readers = @"C:\Users\ipell\source\repos\CashRegister\CashRegister\Products.txt";
            //List<string> line = File.ReadAllLines(readers).ToList();
            //foreach (var reads in line)
            //{
            //    string[] productSplit = reads.Split(' ');

            //    Produces newProduct = new Produces();

            //    newProduct.ProductName = productSplit[0];
            //    newProduct.ProductPrice = Double.Parse(productSplit[1]);
            //    newProduct.ProductType = productSplit[2];
            //    newProduct.ProductID = Int32.Parse(productSplit[3]);

            //    Products.Add(newProduct);
            //}




            //Products.Add(new Produces
            //{
            //    ProductName = "Potato",
            //    ProductPrice = 22.70,
            //    ProductType = "kg",
            //    ProductID = 200
            //});
            //Products.Add(new Produces
            //{
            //    ProductName = "Coffee",
            //    ProductPrice = 120,
            //    ProductType = "kg",
            //    ProductID = 300
            //});
            //Products.Add(new Produces
            //{
            //    ProductName = "Bread",
            //    ProductPrice = 26.50,
            //    ProductType = "st",
            //    ProductID = 400
            //});
            //Products.Add(new Produces
            //{
            //    ProductName = "Milk",
            //    ProductPrice = 9,
            //    ProductType = "st",
            //    ProductID = 500
            //});

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
            //string theProduct = "";
            var readers = "Products.txt";
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

                        //var productFinal = item.ProductID.ToString();
                        

                        //Console.WriteLine("");
                        Console.WriteLine(item.ProductName + " " + item.ProductPrice + " * " + data2 + " = " + (item.ProductPrice * data2));
                        Produces.theProduct = Console.ReadLine();
                        string input = Console.ReadLine();
                        finalProducts.Add(input);
                    }
                    //else
                    //{
                    //    Console.WriteLine("TEST FAIL");
                    //}
                    
                }
                
                
            }
            
        }

        public void TextOfMaths()
        {
            
        }
    }
}


