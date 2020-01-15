using System;
using System.Collections;
using System.Collections.Generic;

namespace Student.Services
{
    public interface IStudentService
    {
        IEnumerable<Model.Student> GetAll();

        Model.Student Create(Model.Student student);
        Model.Student Delete(string id);
        Model.Student FindById(string id);
        Model.Student Update(Model.Student s);
    }
}