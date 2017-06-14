using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vishop.Models;

namespace Vishop.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { set; get; }
    }
}