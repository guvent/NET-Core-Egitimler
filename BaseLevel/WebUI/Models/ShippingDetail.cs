using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ShippingDetail
    {
        //[Required(ErrorMessage = "İsim Gerekli!")]
        public string FirstName { get; set; }
        
        //[Required(ErrorMessage = "Soyisim Gerekli!")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "EPosta Gerekli!")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string City { get; set; }
        
        public string Address { get; set; }
        
        //[Required]
        //[Range(18,65)]
        public int Age { get; set; }
    }
}
