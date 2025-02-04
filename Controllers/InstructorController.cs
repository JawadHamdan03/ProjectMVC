using CoursesCenterProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursesCenterProject.Controllers;

public class InstructorController : Controller
{
   public CoursesCenterProject_DB DB =new CoursesCenterProject_DB();
    public IActionResult Index()
    {
        return View("Index",DB.Instructors.Include(i => i.Department).Include(i=> i.Course).ToList());
    }
    [HttpGet]
    public IActionResult Edit(int id )
    {
        ViewBag.Departments = DB.Departments.ToList();
        ViewBag.Courses = DB.Courses.ToList();
        Instructor instructor = DB.Instructors.FirstOrDefault(i=> i.Id == id);
        return View("Edit",instructor);
    }
    [HttpPost]
    public IActionResult SaveEdit(Instructor instructorRCV)
    {
        if (instructorRCV != null)
        {

            if (instructorRCV.CourseId==null)
            {
                return Content("CourseId is Required");
            }


            Instructor instructorMatched = DB.Instructors.FirstOrDefault(i => i.Id == instructorRCV.Id);
            
                instructorMatched.Id = instructorRCV.Id;
                instructorMatched.Name = instructorRCV.Name;
                instructorMatched.ImageURL = instructorRCV.ImageURL;
                instructorMatched.Salary = instructorRCV.Salary;
                instructorMatched.Address = instructorRCV.Address;
                instructorMatched.DepartmentId = instructorRCV.DepartmentId;
                instructorMatched.CourseId = instructorRCV.CourseId;
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
        return Content("Failed to Save Changes");
    }

    public IActionResult Remove(int id)
    {
        Instructor instructor = DB.Instructors.FirstOrDefault(i => i.Id == id);
        DB.Instructors.Remove(instructor);
        DB.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Add()
    {
        ViewBag.Departments=DB.Departments.ToList();
        ViewBag.Courses = DB.Courses.ToList();
        return View("Add");
    }
    public IActionResult SaveAdd(Instructor RCV)
    {
        DB.Instructors.Add(RCV);
        DB.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult Search(string name )
    {
        List<Instructor> instructors= DB.Instructors.Include(i=> i.Department).Include(i=> i.Course).Where(i=> i.Name.Contains(name)).ToList();
        return View("Search",instructors);
    }

}



