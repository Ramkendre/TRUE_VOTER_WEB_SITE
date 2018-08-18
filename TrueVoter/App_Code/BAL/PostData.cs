using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrueVoter.App_Code.BAL
{
    public class PostData
    {
        public class Msg
        {
            public string message { get; set; }
            public Msg(string msg)
            { this.message = msg; }
        }


        public string ApplicationId { get; set; }
        public string senderId { get; set; }
        public Msg data { get; set; }
        public List<string> registration_ids { get; set; }
        public string collapse_key { get; set; }
        public int time_to_live { get; set; }
        public bool delay_while_idle { get; set; }


        public PostData(string applicationId, string SenderId, string Message, List<string> regids)
        {
            this.ApplicationId = applicationId;
            this.senderId = SenderId;
            this.data = new Msg(Message); ;

            this.registration_ids = regids;
        }
    }
}