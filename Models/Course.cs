using System.ComponentModel.DataAnnotations;

namespace CoursesCenterProject.Models;

public class Course
{
    public int Id { get; set; }
    [Required]
    [MaxLength(20,ErrorMessage ="The name can't be more than 20 letters")]
    [MinLength(3,ErrorMessage ="The name can't be less than 3 letters")]
    [UniqueName(msg ="The name is already used")]
    public string  Name { get; set; }
    [Required]
    [Range(50,100)]
    public int Degree { get; set; }
    [Required]
    [LessThanDegree(ErrorMessage ="the MinDegree Must be less tahn Degree")]
    public int MinDegree { get; set; }
    public int DepartmentId { get; set; }



    public Department Department { get; set; }

    public List<Instructor> Instructors { get; set; }
    public List<CourseResults> CourseResults { get; set; }
}
