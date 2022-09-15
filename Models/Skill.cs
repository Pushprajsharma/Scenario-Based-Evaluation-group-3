using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Post_Experience.Models
{
    public class Skill
    {
        
        public int SkillId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required]
        public string SkillName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public int ExInYear { get; set; }
        [Required]
        public string PostalCode { get; set; }

        
        public virtual Employee employee { get; set; }

    }

}
