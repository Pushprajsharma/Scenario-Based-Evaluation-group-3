using Post_Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post_Experience.Repository
{
    public class EmployeeRepo : IEmployeeRepository
    {
        appDbContext _context;
        public EmployeeRepo(appDbContext context)
        {
            _context = context;
        }
        public void addEmployee(Employee obj)
        {
            _context.Employees.Add(obj);
            _context.SaveChanges();
        }

        public void addSkill(Skill obj)
        {
            _context.Skills.Add(obj);
            _context.SaveChanges();
        }

        public void deleteEmployee(int empId)
        {
            Employee emp = _context.Employees.Find(empId);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
        }

        public void deleteSkill(int skillId)
        {
            Skill skill = _context.Skills.Find(skillId);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }

        }

        public List<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public List<Skill> getAllSkill(int empId)
        {
            
            return _context.Skills.Where(item => item.EmployeeId == empId).ToList();
        }


        public Employee GetEMployeeById(int empId)
        {
            Employee myEmp = _context.Employees.Find(empId);
            return myEmp;
        }

        public Employee getEmployeeByObj(Employee obj)
        {
            return _context.Employees.Find(obj.Email);
        }

        public Skill getSkill(int skillId)
        {
            return _context.Skills.Find(skillId);
        }

        public void updateEmployee(Employee obj)
        {
            _context.Employees.Update(obj);
            _context.SaveChanges();
        }

        public void updateSkill(Skill obj)
        {
            _context.Skills.Update(obj);
            _context.SaveChanges();

        }
    }
}
