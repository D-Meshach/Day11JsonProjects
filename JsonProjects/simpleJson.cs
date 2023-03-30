using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

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
            public string ProductWeight { get; set; }
            [JsonProperty("ProductPricePerKg")]
            public string ProductPricePerKg { get; set; }

        }
        public simpleJson() {
            var filepath = @"D:\Visual_studio_projects\TESTING\JsonProjects\JsonProjects\Product.json";
            string data = null;
            int i = 1;
            using (var filereader =new StreamReader(filepath))
            {
                data = filereader.ReadToEnd();
            }
            var dataToJson = JsonConvert.DeserializeObject<List<ProductDetail>>(data);
            foreach (ProductDetail product in dataToJson)
            {
                Console.WriteLine("Product " + i);
                Console.WriteLine("Product Name=" + product.ProductName);
                Console.WriteLine("Product weight=" + product.ProductWeight);
                Console.WriteLine("Product Price Per Kg=" + product.ProductPricePerKg);
                Console.WriteLine("---------------------------------");
                i++;
            }
        }
    }
}
