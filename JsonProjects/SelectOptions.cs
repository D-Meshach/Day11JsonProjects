using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonProjects
{
    internal class SelectOptions
    {
        public SelectOptions()
        {
            string loopCheck = "n";
            while (loopCheck == "n")
            {
                Console.WriteLine("\n 1)Simple Json list program and Inventory \n 2) Stock Management \n 3) Commercial Data Processing(Stock Account) \n 4)Deck Of Cards \n Enter Option");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {   //UC1 and UC2
                    case 1: simpleJson simple = new simpleJson(); break;
                    case 2: StockManagement manage = new StockManagement();break;
                    case 3: CommercialProcess.StockAccount commercial = new CommercialProcess.StockAccount(); break;
                    case 4: DeckOfCards decks = new DeckOfCards();break;

                    default: Console.Write("Enter the valid number"); break;
                }
                Console.WriteLine("Do You want to exit (y/n)?");
                loopCheck = Convert.ToString(Console.ReadLine());
            }



        }
    }
}
