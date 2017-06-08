using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vishop.Models
{
    public class MembershipType
    {
        public byte id { get; set; }
        public short signupFee { get; set; }
        public byte durationMonths { get; set; }
        public byte discountRate { get; set; }
        public string name { get; set; }

    }
        
}