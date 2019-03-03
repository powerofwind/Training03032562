using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myApi.Models;

namespace myApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        public static List<Student> Students = new List<Student>
        {
            new Student{
                Id= Guid.NewGuid().ToString(),
                Name = "นายแดง",
                Age = 5,
                ProfileImage= "https://picpost.mthai.com/storage/uploads/2019/01/2605510.jpg"
            },
             new Student{
                Id= Guid.NewGuid().ToString(),
                Name = "นายดำ",
                Age = 6,
                ProfileImage= "http://www.tvpoolonline.com/wp-content/uploads/2017/08/1501584005_6.jpg"
            },
             new Student{
                Id= Guid.NewGuid().ToString(),
                Name = "นายเขียว",
                Age = 5,
                ProfileImage= "https://i.pinimg.com/236x/4b/e1/3d/4be13dd30751903bc5ef21e67e1e1a8c.jpg"
            },
        };

        [HttpGet]
        public List<Student> GetAllStudents()
        {
            return Students;
        }

        [HttpGet("{id}")]
        public Student GetStudent(string id)
        {
            return Students.Find(it => it.Id == id);
        }

        [HttpPost]
        public void CreateStudent([FromBody]Student newStudent)
        {
            newStudent.Id = Guid.NewGuid().ToString();
            Students.Add(newStudent);
        }

        [HttpPut]
        public void UpdateStudent([FromBody]Student newStudent)
        {
            var oldStudent = Students.Find(it => it.Id == newStudent.Id);
            Students.Remove(oldStudent);
            Students.Add(newStudent);
        }

        [HttpDelete("{id}")]
        public void DeleteStudent(string id)
        {
            var student = Students.Find(it => it.Id == id);
            Students.Remove(student);
        }
    }
}
