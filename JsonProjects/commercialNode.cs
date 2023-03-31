using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonProjects
{
    public class commercialNode
    {
        public int amount;
        public commercialNode next;
        public string symbol;
        public DateTime dateTime;
        public commercialNode(int amount,string symbol,DateTime dateTime)
        {
            this.amount = amount;
            this.symbol=symbol;
            this.dateTime = dateTime;
            next = null;
        }
    }
}
