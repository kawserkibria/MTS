using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Commissionslab
    {
        public string GroupName { get; set; }
        public double dblFromRange { get; set; }
        public double dblToRange { get; set; }
        public double dblPercentage { get; set; }
        public string strDate { get; set; }
    }
}