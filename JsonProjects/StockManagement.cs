using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JsonProjects
{
    [Serializable]
    public class StockProperty
    {
        [JsonProperty("StockName")]
        public string StockName { get; set; }
        [JsonProperty("NumberOfShare")]
        public int NumberOfShare { get; set; }
        [JsonProperty("SharePrice")]
        public int SharePrice { get; set; }
    }
    internal class StockManagement
    {
        public StockManagement()
        {
            Console.WriteLine("Reading from Stocks.json");
            string file = @"D:\Visual_studio_projects\TESTING\JsonProjects\JsonProjects\Stocks.json";
            string texts;
            using (var filereader = new StreamReader(file))
            {
                texts = filereader.ReadToEnd();
            }
            var dataJsonSerialize = JsonConvert.DeserializeObject<List<StockProperty>>(texts);
            int i = 0,totalStock=0;
            foreach (StockProperty stocks in dataJsonSerialize)
            {
                i++;
                Console.WriteLine("Product " + i);
                Console.WriteLine("Stock Name"+stocks.StockName);
                Console.WriteLine("Number of Share" + stocks.NumberOfShare);
                Console.WriteLine("Share price" + stocks.SharePrice);
                Console.WriteLine("Total Share Price of " + stocks.SharePrice*stocks.NumberOfShare);
                Console.WriteLine("----------------------------------------------------------------");
                totalStock += (stocks.SharePrice * stocks.NumberOfShare);
                

                
            }
            Console.WriteLine("Total Stocks="+i+" Total price of stocks =" + totalStock);
        }
        
    }
}
