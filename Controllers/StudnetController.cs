using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo_Swagger.FIlters;
using WebApiDemo_Swagger.Models;

namespace WebApiDemo_Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[CustomErrorFilter]
    
    public class StudentController : ControllerBase
    {
        static List<Student> _studentList = null;
        void Initialize()
        {
            _studentList = new List<Student>()
           {
               new Student() { StudentId=1, Name="Ajay" , Batch="B001", Marks=89, DateOfBirth=Convert.ToDateTime("12/12/2020")},

               new Student() { StudentId=2, Name="Deepak" , Batch="B002", Marks=78, DateOfBirth=Convert.ToDateTime("10/06/2020")},
           };

        }

        public StudentController()
        {
            if (_studentList == null)
            {
                Initialize();
            }

        }
        // GET: api/Students
       
        [HttpGet]
       
        public IActionResult Get()
        {
            try
            {
                throw new Exception("There are no records");
                return Ok(_studentList);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        //[CustomErrorFilter]
        public Student GetById(int id)
        {
            Student student = _studentList.Where(x => x.StudentId == id).FirstOrDefault();
            //if (student == null)
            //    throw new CustomException("This record does not exist");
            //else 
            return student;
        }
        [HttpPost]
       
        public void Post(Student student)
        {
            Student obj = _studentList.FirstOrDefault(x => x.StudentId == student.StudentId);
            if(obj!=null)
            {
                throw new AlreadyExists("This ID already exists");

            }
                 else 
                _studentList.Add(student);
           
            
        }
        // PUT: api/Students/5
        [HttpPut]
        [Route("{id:int}")]
        public void Put(int id, Student objStudent)
        {
            Student student = _studentList.Where(x => x.StudentId == id).FirstOrDefault();

            if (student != null)
            {
                foreach (Student temp in _studentList)
                {
                    if (temp.StudentId == id)
                    {
                        temp.Name = objStudent.Name;
                        temp.DateOfBirth = objStudent.DateOfBirth;
                        temp.Batch = objStudent.Batch;
                        temp.Marks = objStudent.Marks;
                    }
                }
            }
        }

        // DELETE: api/Students/5
        [HttpDelete]
        [Route("{id:int}")]
        public void Delete(int id)
        {
            Student student = _studentList.Where(x => x.StudentId == id).FirstOrDefault();

            if (student != null)
            {
                _studentList.Remove(student);
            }


        }
    }
}