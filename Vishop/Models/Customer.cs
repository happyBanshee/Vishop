using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vishop.Models
{
    public class Customer
    {
        public int Id { set; get; }

        [Required(ErrorMessage ="Please enter customer's name.")]
        [StringLength(255)]
        public string Name { set; get; }

        public bool IsSubscribedToNewsletter { set; get; }

        public MembershipType MembershipType { set; get; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { set; get; }

        [Display(Name = "Date of birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { set; get; }
    }
}