using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Model
{
//    [Table("Students")]
    public  class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        
//        private string Email { get; set; }
    }
}