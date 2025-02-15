using CoursesCenterProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursesCenterProject.Controllers;

public class CourseController : Controller
{
    CoursesCenterProject_DB DB= new CoursesCenterProject_DB();

    public IActionResult Index()
    {

        return View("Index",DB.Courses.Include(c => c.Department).ToList());
    }

    public IActionResult Add()
    {
        ViewBag.Departments = DB.Departments.ToList();
            return View("Add");

        }
    public IActionResult SaveAdd(Course RCV)
    {

        if(ModelState.IsValid){
            DB.Courses.Add(RCV);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Departments = DB.Departments.ToList();
        return View("Add", RCV);

    }

    public IActionResult Edit(int id )
    {
        Course course = DB.Courses.Include(c=> c.Department).FirstOrDefault(c=> c.Id==id);
        ViewBag.Departments = DB.Departments.ToList();
        return View("Edit", course);
    }
    public IActionResult SaveEdit(Course RCV)
    {
        if (RCV != null)
        {
            var res = DB.Courses.FirstOrDefault(c => c.Id == RCV.Id);
            res.Name= RCV.Name;
            res.Degree = RCV.Degree;
            res.MinDegree = RCV.MinDegree;
            res.DepartmentId = RCV.DepartmentId;
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        return Content($"Failed to Edit {RCV.Id }{RCV.Name} ");
    }

    public IActionResult Remove (int id)
    {
        DB.Courses.Remove(DB.Courses.FirstOrDefault(c=> c.Id==id));
        DB.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Search(string name )
    {
        var res = DB.Courses.Include(c=> c.Department).Where(c=> c.Name.Contains(name)).ToList();
        return View("Search",res);
    }
}