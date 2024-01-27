using BusinessAccessLayer.Abstract;
using Data.DatabaseContext;
using Model;
using System.Data.Entity;

namespace BusinessAccessLayer.Implementation
{
    public class EmployeeService:IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployee(Employee model)
        {
            try
            {
                var result = await _context.Employees.AddAsync(model);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            try
            {
                var result = _context.Employees.ToList();
                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public bool UpdateEmployee(Employee model)
        {
            try
            {
                var result = _context.Employees.Find(model.EmployeeId);
                if (result != null)
                {
                    result.Name = model.Name;
                    result.Email = model.Email;
                    result.Contact = model.Contact;
                    result.Addres = model.Addres;
                    _context.Employees.Update(result);
					var res = _context.SaveChanges();
                    if(res>0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                var delete = _context.SaveChanges();
                if (delete > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
