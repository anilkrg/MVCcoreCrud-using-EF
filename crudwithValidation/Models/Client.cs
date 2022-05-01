using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace crudwithValidation.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name ="Client Name")]
        [Required(ErrorMessage = "Must be fill Client Name")]
        [MinLength(3,ErrorMessage ="Name must be Minimum 3 charchter")]
        public string Name { get; set; }


        [Display(Name = "Client Address")]
        [Required(ErrorMessage = "Must be fill Client Address")]
        [MaxLength(200, ErrorMessage = "Maximum 200 character")]


        public string Address { get; set; }

        [Display(Name = "Client City")]
        [Required(ErrorMessage = "Must be fill Client City")]
        public string City { get; set; }
        
        [Display(Name = "Client Mobile Number")]
        [Required(ErrorMessage ="Must be fill Client Mobile Number")]
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", ErrorMessage ="Invalid mobile number")]
        public string Mobile { get; set; }
    }
}
