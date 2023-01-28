using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webapp.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int RollNo { get; set; }
        public string Description { get; set; }
    }

    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        public DbSet<StudentModel> Tb_Student { get; set; }
    }

}
