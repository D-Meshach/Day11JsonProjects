using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;

namespace JsonProjects
{
    internal class simpleJson
    {
        [Serializable]
        public class ProductDetail
        {
            [JsonProperty("ProductName")]
            public string ProductName { get; set; }
            [JsonProperty("ProductWeight")]
            public int ProductWeight { get; set; }
            [JsonProperty("ProductPricePerKg")]
            public int ProductPricePerKg { get; set; }
            [JsonProperty("TotalPrice")]
            public int TotalPrice { get; set; }

        }
        public simpleJson() {
            Console.WriteLine("Reading from Product.json");
            var filepath = @"D:\Visual_studio_projects\TESTING\JsonProjects\JsonProjects\Product.json";
            string data = null;
            int i = 1;
            int price;
            using (var filereader =new StreamReader(filepath))
            {
                data = filereader.ReadToEnd();
            }
            var dataToJson = JsonConvert.DeserializeObject<List<ProductDetail>>(data);
            // String jsonformat = "[";
             List<ProductDetail> lists=new List<ProductDetail>();
            foreach (ProductDetail product in dataToJson)
            {
                Console.WriteLine("Product " + i);
                Console.WriteLine("Product Name=" + product.ProductName);
                Console.WriteLine("Product weight=" + product.ProductWeight);
                Console.WriteLine("Product Price Per Kg=" + product.ProductPricePerKg);
                price = product.ProductWeight * product.ProductPricePerKg;
                Console.WriteLine("Calculation of Total Price of "+product.ProductName+"=" + price);
                Console.WriteLine("---------------------------------");
                i++;
                lists.Add(new ProductDetail { ProductName = product.ProductName,ProductWeight=23,ProductPricePerKg=24 ,TotalPrice=price });

                //jsonformat="[{\"ProductName\":\"" + product.ProductWeight + "\",\"ProductWeight\":\""+product.ProductWeight+"\",\"ProductPricePerKg\":\""+product.ProductPricePerKg+"\",\"TotalPrice\":\""+price+"\"}";


            }
           // jsonformat += "]";
           // Console.WriteLine(jsonformat.Trim());
          
            var jsonformatChange = JsonConvert.SerializeObject(lists);

            //var deserialize = JsonConvert.DeserializeObject<ProductDetail>(jsonformatChange);
            Console.WriteLine("After Calculating Total Price the Serialised format");
            Console.WriteLine(jsonformatChange);

        }
    }
}
