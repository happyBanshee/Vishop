using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vishop.Models
{
    public class Customer
    {
        public int id { set; get; }
        [Required]
        [StringLength(255)]

        [Display(Name = "Name:")]
        public string name { set; get; }
        public bool isSubscribedToNewsletter { set; get; }
        public MembershipType membershipType { set; get; }
        [Display(Name = "Membership Type:")]
        public byte membershipTypeId { set; get; }
        [Display(Name = "Date of birth:")]
        public DateTime? birthdate { set; get; }
    }
}