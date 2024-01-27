using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Addres { get; set; }
    }
}
