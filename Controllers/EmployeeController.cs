using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Post_Experience.Repository;
using Post_Experience.Models;

namespace Post_Experience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var empList = _repo.GetAllEmployee();
            return empList;
        }

        [HttpGet]
        [Route("getSkill/{id}")]
        public IEnumerable<Skill> GetSkill(int id)
        {
            var skillList = _repo.getAllSkill(id);
            return skillList;
        }
    }
}
