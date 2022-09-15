using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Post_Experience.Models;

namespace Post_Experience.Repository
{

    public interface IEmployeeRepository
    {
        Employee getEmployeeByObj(Employee obj);
        List<Employee> GetAllEmployee();
        Employee GetEMployeeById(int empId);

        void addEmployee(Employee obj);

        void updateEmployee(Employee obj);

        void deleteEmployee(int empId);

        List<Skill> getAllSkill(int empId);

        void addSkill(Skill obj);

        void deleteSkill(int skillId);

        void updateSkill(Skill obj);

        Skill getSkill(int skillId);


    }
}
