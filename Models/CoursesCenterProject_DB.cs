using Microsoft.EntityFrameworkCore;

namespace CoursesCenterProject.Models;

public class CoursesCenterProject_DB : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<CourseResults> CourseResults { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=JAWAD-HAMDAN;Initial Catalog=CoursesCenterProject_DB;Integrated Security=True;Encrypt=False;Trusted_Connection=True;");
    }

}
