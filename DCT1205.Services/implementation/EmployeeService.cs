using DCT1205.Entity;
using DCT1205.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DCT1205.Services.implementation
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsSync(int id)
        {
            var employee = GetById(id);
            if(employee != null)
            {
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
            }                    
        }

        public async Task DeleteEmployee(Employee employee)
        {
            _context?.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employee.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employee.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(Employee employee)
        {
            _context.Employee.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var employee = GetById(id);
           _context.Employee.Update(employee);
           await _context.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        {
            var ListEmployeeForPay = _context.Employee.Select(e => new SelectListItem
            {
                Text = e.FullName,
                Value = e.Id.ToString()
            });
            return ListEmployeeForPay;
        }
    }
}
