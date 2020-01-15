using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Student.Repository;

namespace Student.Services
{
    public class StudentServices:IStudentService
    {
        
        private  readonly StudentRepository _studentRepository;

        public StudentServices(StudentRepository studentRepository)
        {
//            _studentRepository = new StudentRepository(new DbContextOptions<StudentRepository>(
//                ));
            _studentRepository = studentRepository;
        }


        public IEnumerable<Model.Student> GetAll()
        {
            return _studentRepository.Students;

        }

        public Model.Student Create(Model.Student student)
        {
            _studentRepository.Students.Add(student);
            _studentRepository.SaveChanges();
            return student;
        }

        public Model.Student Delete(string id)
        {
            Model.Student s=_studentRepository.Students.Find(id);
            if (s!=null)
            {
                _studentRepository.Remove(s);
                _studentRepository.SaveChanges();
            }

            return s;
        }

        public Model.Student FindById(string id)
        {
            return  _studentRepository.Students.Find(id);
        }

        public Model.Student Update(Model.Student s)
        {
            var student = _studentRepository.Students.AsNoTracking().FirstOrDefault(d => d.Id==s.Id);
            if (student!=null)
            {
                
                _studentRepository.Students.Update(s);
                _studentRepository.SaveChanges();
                return _studentRepository.Students.Find(s.Id);
            }

            return null;

        }
    }
 
}