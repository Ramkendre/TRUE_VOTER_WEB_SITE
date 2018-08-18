using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrueVoter.App_Code.BAL
{
    public class SearchBAL
    {
        private string mobleNo = null;
        public SearchBAL()
        { }
        public SearchBAL(string Value)
        {
            this.mobleNo = Value;
        }
        public bool isValid()
        {
            return (this.mobleNo==null && String.IsNullOrEmpty(this.mobleNo) && String.IsNullOrWhiteSpace(this.mobleNo))?false:true;
        }


    }
}