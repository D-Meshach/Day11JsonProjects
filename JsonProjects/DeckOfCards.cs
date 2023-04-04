using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace JsonProjects
{
    internal class DeckOfCards
    {
       public string[,] player = new string[10, 10];
        public DeckOfCards()
        {
            DeckCardFunction();
        }

        public void DeckCardFunction()
        {
            int[,] decks =new int[,] { };
            Random random = new Random();
           
            int i = 0,j,playerCount=0;
            
            while (i<36)
            {
                j = 0;
                Console.WriteLine("Player " + playerCount + " cards");
               
                while (j < 9)
                {
                    
                    var rank = random.Next(1, 14);
                    var suit = random.Next(20, 23);
                    string deckshuffel=decktype(rank, suit);
                    int k = 0, l = 0;

                    /*while (k < 2)
                    {
                        while (l < 2)
                        {
                            if (player[k, l] == decktype(rank, suit))
                                Console.WriteLine("Repeated");

                            l++;
                        }
                        k++;
                    }*/
                   
                   
                    bool check = true;
                    while (check==true)
                    {

                        check = checkplayer(player,deckshuffel);
                        if (check == true)
                        {
                            rank = random.Next(1, 14);
                            suit = random.Next(20, 23);
                            deckshuffel = decktype(rank, suit);
                        }
                    }
                    player[playerCount, j] = deckshuffel;
                    Console.WriteLine(player[playerCount, j]);
                    i++;
                    j++;
                }
                Console.WriteLine("---------");
                playerCount++;

            }

        }
        public string decktype(int rank,int suit)
        {
            string suitname,rankname;//11jack 12 queen 13 king 1Ace

            if (rank == 11)
            {
                rankname = "Jack";
            }
            else if (rank == 12)
            {
                rankname = "Queen";
            }
            else if (rank == 13)
            {
                rankname = "King";
            }
            else if (rank == 1)
            {
                rankname = "Ace";
            }
            else 
            {
                rankname = ""+rank;
            }
            if (suit == 20)
            {
                suitname = "Club";
            }
            else if (suit == 21)
            {
                suitname = "Diamond";
            }
           else if (suit == 22)
            {
                suitname = "Heart";
            }
           else if (suit == 23)
            {
                suitname = "Spade";
            }
            else
            {
                suitname = "error";
            }

            return rankname+"-"+ suitname;
        }

        public bool checkplayer(string[,] player,string deckcard)
        {
            int k = 0;

            while (k < 4)
            {
                int l = 0;
                while (l < 9)
                {
                    if (player[k, l] == deckcard)
                    {
                       // Console.WriteLine("Repeated="+deckcard);
                      // k=0; l = 0;
                        return true;
                        
                    }

                    l++;
                }
                k++;
            }
            return false;
            
           

        }
    }
}
