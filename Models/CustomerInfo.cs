using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerIdentityAPI.Models
{
    public class CustomerInfo
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Key]
        public string Phonenumber { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]       
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

      
    }
}
