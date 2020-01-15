using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student.Services;

//using Student.Services;


namespace Student.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [AllowAnonymousAttribute]
        public IEnumerable<Model.Student >Get()
        {
            return  _studentService.GetAll();


        }
        [HttpGet("{id}")]
        public ActionResult<Model.Student> Get(string id)
        {
           Model.Student s=_studentService.FindById(id);
           if (s!=null)
           {
               return s;
           }

           return null;
        }

        
        [HttpPost]
        public Model.Student Post([FromBody] Model.Student student)
        {
            return _studentService.Create(student);
        }
        [HttpDelete("{id}")]
        public Model.Student Delete(string id)
        {
            return  _studentService.Delete(id);
        }
        [HttpPut]
        public Model.Student Put([FromBody] Model.Student student)
        {
            return _studentService.Update(student);
        }
        
        
        
        

    }
}