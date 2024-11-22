using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Students
    {
        public int StudentId {  get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The name must have atleast 3 characters.")]
        public string Name { get; set; }
        [Required]
        [Range(18, 25, ErrorMessage = "Age must be between 18 and 25.")]
        public int Age {  get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The branch must have atleast 3 characters.")]
        public string Branch { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"StudentId: {StudentId}, Name: {Name}, Age: {Age}, Branch: {Branch}, PhoneNumber: {PhoneNumber}";
        }
    }
}
