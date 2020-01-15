using Microsoft.EntityFrameworkCore;

namespace Student.Repository
{
    public interface IStudentRepository
    {
        DbSet<Model.Student> Students { get; set; }
    }
}