using BlazorServerAppSample.Data;
using BlazorServerAppSample.Models;

namespace BlazorServerAppSample.Services
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;

        }
        public List<EmployeeModel> GetEmployee()
        {
            return _context.tblEmployee.ToList();
        }
        public EmployeeModel GetEmployee(int empId)
        {
            return _context.tblEmployee.FirstOrDefault(p => p.Id == empId);
        }

        public void AddEmployee(EmployeeModel emp)
        {
            _context.tblEmployee.Add(emp);
            _context.SaveChanges();
        }

        public void UpdateEmployee(EmployeeModel updatedEmp)
        {
            var existingTask = _context.tblEmployee.FirstOrDefault(p => p.Id == updatedEmp.Id);
            if (existingTask != null)
            {
                existingTask.EmpName = updatedEmp.EmpName;
                existingTask.EmpCity = updatedEmp.EmpCity;
                _context.SaveChanges();
            }
        }

        public void DeleteEmployee(int empId)
        {
            var empToDelete = _context.tblEmployee.FirstOrDefault(p => p.Id == empId);
            if (empToDelete != null)
            {
                _context.tblEmployee.Remove(empToDelete);
                _context.SaveChanges();
            }
        }
    }
}
