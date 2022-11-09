using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class StockItem
    {
        public string strItemName { get; set; }
        public string strUnit { get; set; }
        public double dblClsBalance { get; set; }
    }
}