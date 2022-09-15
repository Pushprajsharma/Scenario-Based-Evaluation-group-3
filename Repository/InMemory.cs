using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Post_Experience.Models;
using Post_Experience.Repository;

namespace Post_Experience.Repository
{
    public class InMemory : IEmployeeRepository
    {
        private static List<Employee> _employeeList = new List<Employee>()
            {
              new Employee(){EmployeeId=1,FirstName="Aaron",LastName="Hawkins",password="arron@123",CellNumber="(660) 663-4518",Email="aron.hawkins@aol.com" },
              new Employee(){EmployeeId=2,FirstName="Hedy",LastName="Greene",password="hedy@123",CellNumber="(608) 265-2215",Email="hedy.greene@aol.com" },
              new Employee(){EmployeeId=3,FirstName="Melvin",LastName="Porter",password="melvin@123",CellNumber="(959) 119-8364",Email="melvin.porter@aol.com"}
            };

        private static List<Skill> _skillList = new List<Skill>()
            {
            new Skill(){SkillId=1,EmployeeId=1,SkillName="Microsoft Office Suite",Role="Business Analyst",ExInYear=2},
            new Skill(){SkillId=2,EmployeeId=1,SkillName="Testing",Role="Developer",ExInYear=3},
            new Skill(){SkillId=3,EmployeeId=1,SkillName="Stakeholder Management",Role="Project Lead",ExInYear=4}
           };

        public void addEmployee(Employee employee)
        {
            if (_employeeList.Count == 0)
            {
                employee.EmployeeId = 1;
            }
            else
            {
                employee.EmployeeId = _employeeList.Max(e => e.EmployeeId) + 1;

            }

            _employeeList.Add(employee);
             
        }

        public void addSkill(Skill skill)
        {
            if (_skillList.Count == 0)
            {
                skill.SkillId = 1;
            }
            else
            {
                skill.SkillId = _skillList.Max(e => e.SkillId) + 1;

            }

            _skillList.Add(skill);

        }

        public void deleteEmployee(int empId)
        {
            Employee e = _employeeList.FirstOrDefault(e=> e.EmployeeId == empId);
            if (e != null)
            {
                _employeeList.Remove(e);
            }
        }

        public void deleteSkill(int skillId)
        {
            Skill e = _skillList.FirstOrDefault(e => e.SkillId == skillId);
            if (e != null)
            {
                _skillList.Remove(e);
            }
        }

        public List<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public List<Skill> getAllSkill(int empId)
        {
            return _skillList;
        }

        public Employee GetEMployeeById(int empId)
        {
            throw new NotImplementedException();
        }

        public Employee getEmployeeByObj(Employee obj)
        {
            return _employeeList.FirstOrDefault(e => e.Email == obj.Email && e.password == obj.password);
        }

        public Skill getSkill(int skillId)
        {
            return _skillList.FirstOrDefault(e => e.SkillId == skillId);
        }

        public void updateEmployee(Employee obj)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.EmployeeId == obj.EmployeeId);
            if (employee != null)
            {
                employee.FirstName = obj.FirstName;
                employee.LastName = obj.LastName;
                employee.password = obj.password;
                employee.CellNumber = obj.CellNumber;
                employee.Email = obj.Email;

            }
        }

        public void updateSkill(Skill obj)
        {
            Skill skill = _skillList.FirstOrDefault(e => e.SkillId == obj.SkillId);

            if (skill != null)
            {
                skill.SkillName = obj.SkillName;
                skill.Role = obj.Role;
                skill.PostalCode = obj.PostalCode;
                skill.ExInYear = obj.ExInYear;
            }
        }
    }
}
