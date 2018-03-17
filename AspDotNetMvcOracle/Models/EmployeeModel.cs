using System.ComponentModel.DataAnnotations;

namespace AspDotNetMvcOracle.Models
{
    public class EmployeeModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; }
    }
}