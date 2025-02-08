using System.ComponentModel.DataAnnotations;

namespace CoursesCenterProject.Models
{
    public class LessThanDegree : ValidationAttribute
    {
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var course = (Course)(validationContext.ObjectInstance);
            if (Convert.ToInt32(value) >course.Degree)
            {
                return new ValidationResult("The MinDegree can't be more than the Degree");
            }
            return ValidationResult.Success;
        }
    }
}
