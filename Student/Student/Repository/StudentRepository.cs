using Microsoft.EntityFrameworkCore;

namespace Student.Repository
{
    
    public  class StudentRepository:DbContext {
        public StudentRepository(DbContextOptions<StudentRepository>options):base(options){}

        public DbSet<Model.Student> Students { get; set; }
        
        
        
    }
}