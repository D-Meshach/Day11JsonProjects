using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JsonProjects
{
    internal class CommercialProcess
    {
        public class StockProperties
        {
            
            public string stockSymbol { get; set; }
            public int amount { get; set; }
            public DateTime transactionDateTime { get; set; }
        }
        public class StockAccount
        {
            public commercialNode commstart,starthead;
            public StockAccount()
            {
                //Console.WriteLine( DateTime.Now.ToString());
                buy(23, "abc");
                Thread.Sleep(1000);
                buy(25, "xyz");
               buy(26, "yio");
                Thread.Sleep(1000);
                buy(28, "yur");
                //Repetition of purchase not saved
                buy(26, "yio");
                sell(5, "yio");
                sell(29, "rrf");
                sell(48, "yio");
                save("dodo");
                

            }
            public double ValueOf()
            {
                return default;
            }
            public void buy(int amount, string symbol)
            {
                
                /*if (status == true)
                {
                    Console.WriteLine("Stock Already Present");
                }*/
                
                commercialNode comm = new commercialNode(amount, symbol, DateTime.Now);
                if (commstart == null)
                {
                    commstart = comm;
                    starthead = comm;
                    Console.WriteLine("\nCurrent Stocks Available Are");
                    printReport();
                }
                else {
                    bool status = checkstatus(symbol);
                    if (status == true)
                    {
                        updateExisting(symbol,amount);
                        /*Console.WriteLine("\n\n Buying stock symbol=" + comm.symbol);
                        Console.WriteLine("Stock symbol="+symbol+"Already Present");*/
                        Console.WriteLine(symbol+"Updated Successfully -added amount="+amount);
                    }
                    else {
                        Console.WriteLine("\n\n Buying stock symbol=" + comm.symbol);
                    commstart.next = comm;
                    comm = commstart;
                    commstart = commstart.next;
                    }
                    Console.WriteLine("Current Stocks Available Are");
                    printReport();
                }
                 
            }
            public void updateExisting(string symbol,int amount)
            {
                commercialNode comm=starthead;
                while (comm != null)
                {
                    if (comm.symbol == symbol)
                    {
                        comm.amount += amount;
                        break;
                    }
                    comm = comm.next;
                }
            }
            public void sell(int amount, string symbol)
            {
                commercialNode comm = starthead,prevnode=comm;
                Console.WriteLine("Selling" + symbol+"with amount="+amount);
                while (comm != null)
                {

                    /*if (comm.amount == amount && comm.symbol == symbol)
                    {
                        prevnode.next = comm.next;
                        break;
                    }*/
                    if ( comm.symbol == symbol)
                    {
                        int tempAmount = comm.amount;
                        comm.amount -= amount;
                        if (comm.amount < 0)
                        {
                            comm.amount = tempAmount;
                            Console.WriteLine("Insufficient Balance");
                            break;
                        }
                    }

                    //prevnode = comm;
                    comm = comm.next;
                }
                Console.WriteLine("\n\nCurrent Stocks Available After selling");
                printReport();
            }
            public void save(string filename)
            {
                List<StockProperties> list = new List<StockProperties>();
                commercialNode comm = starthead;
                while (comm != null) {
                    list.Add(new StockProperties() { stockSymbol=comm.symbol,amount=comm.amount,transactionDateTime=comm.dateTime});
                    comm = comm.next;
                }
                var jsonFormat = JsonConvert.SerializeObject(list);
                Console.WriteLine("\n\n"+jsonFormat+"\n\n");
                Console.WriteLine("FILE SAVED INSIDE BIN FOLDER KINDLY CHECK :)=)");
                File.WriteAllText(".\\commercial.json",jsonFormat);
                   
            }
            public void printReport()
            {
                commercialNode comm=starthead;
                while (comm != null)
                {
                    Console.WriteLine("Amount="+comm.amount+" Symbol="+comm.symbol+" Date Time="+comm.dateTime);
                    comm = comm.next;
                }
            }
            public bool checkstatus(string symbol)
            {
                commercialNode comm = starthead;
                while (comm != null)
                {
                   // Console.WriteLine(comm.amount);
                    
                    if (comm.symbol == symbol)
                    {
                        return true;
                    }
                    comm = comm.next;

                }
                return false;
            }
            

        }
    }
}
