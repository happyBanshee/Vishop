using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vishop.Models;


namespace Vishop.DTOs
{
    public class CustomerDTO
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { set; get; }

        public bool IsSubscribedToNewsletter { set; get; }

        public byte MembershipTypeId { set; get; }

        [Min18YearsIfAMember]
        public DateTime? Birthdate { set; get; }
    }
}