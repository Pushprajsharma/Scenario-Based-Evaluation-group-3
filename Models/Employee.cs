using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Post_Experience.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required (ErrorMessage = "Please Enter the first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter the last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password shouldn't be blank")]
        public string password { get; set; }

        [Required(ErrorMessage = "Landline shouldn't be blank")]
        public string LandLine { get; set; }

        [Required (ErrorMessage = "Cell number shouldn't be blank")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string CellNumber { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }


    }
}
