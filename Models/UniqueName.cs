using System.ComponentModel.DataAnnotations;

namespace CoursesCenterProject.Models
{
    public class UniqueName : ValidationAttribute
    {
        public string msg { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            CoursesCenterProject_DB DB = new CoursesCenterProject_DB();
            var QryRes = DB.Courses.FirstOrDefault(c=> c.Name==value);
            if (QryRes != null)
            {
                return new ValidationResult("The name is already used");
            }
            
            return  ValidationResult.Success;
        }
    }
}
