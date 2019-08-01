using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerIdentityAPI.Models
{
    public class CustomerAddress
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Key]
        public string Phonenumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int Pincode { get; set; } 
    }
}
