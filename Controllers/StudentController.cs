using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDAL dAL;

        public StudentController(StudentDAL dAL)
        {
            this.dAL = dAL;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetStudents()
        {
            List<Students> students = dAL.GetStudents();
            return new JsonResult(students);
        }
        [HttpPost]
        public JsonResult AddStudent([FromBody] Students data)
        {

            var student = new Students()
            {
                Name = data.Name,
                Age = data.Age,
                Branch = data.Branch,
                PhoneNumber = data.PhoneNumber
            };

            dAL.AddStudent(student);

            return new JsonResult("Student added successfully");

        }

        [HttpGet]
        public JsonResult GetStudentById(int id)
        {
            var student = dAL.GetStudent(id);
            return new JsonResult(student);
        }

        [HttpPost]
        public JsonResult EditStudent([FromBody] Students data)
        {

            //Console.WriteLine("Coming to Add Edit controller");
            //Console.WriteLine(data.ToString());
            var student = new Students()
            {
                StudentId = data.StudentId,
                Name = data.Name,
                Age = data.Age,
                Branch = data.Branch,
                PhoneNumber = data.PhoneNumber
            };
            try
            {
                dAL.EditStudent(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return new JsonResult("Student details Edited successfully");
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            dAL.DeleteStudent(id);

            return new JsonResult("student deleted successfully");
        }
    }
}
