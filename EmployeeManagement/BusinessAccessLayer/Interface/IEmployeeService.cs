using Model;

namespace BusinessAccessLayer.Abstract
{
    public interface IEmployeeService
    {
        public Task AddEmployee(Employee model);
        public Task<IEnumerable<Employee>> GetEmployee();
        public Task<Employee> GetById(int id);
        public bool UpdateEmployee(Employee model);
        
        public bool DeleteEmployee(int id);
    }
}
