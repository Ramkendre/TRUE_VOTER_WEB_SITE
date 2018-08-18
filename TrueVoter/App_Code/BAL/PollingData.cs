using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrueVoter
{
    public class PollingData
    {
        public string userName{get;set;}
        public int wardNo{get;set;}
        public int boothNo { get; set; }
        public int noOfVoting{get;set;}
        public string voters { get; set; }
        public int localBody { get; set; }
        public string imeino { get; set; }
        public string userType { get; set; }
        public string date { get; set; }
        public string refMobileNo { get; set; } 
             
    }
}