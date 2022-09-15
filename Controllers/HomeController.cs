using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Post_Experience.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Post_Experience.Repository;
using Microsoft.AspNetCore.Http;

namespace Post_Experience.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeRepository _repo;

        public HomeController(IEmployeeRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Index(Employee obj)
        {
            _repo.addEmployee(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult checkEmployee(string email, string password)
        {
            List<Employee> allEmp = _repo.GetAllEmployee();

            if (allEmp != null)
            {
                for (int i = 0; i < allEmp.Count; i++)
                {
                    if (allEmp[i].Email.Equals(email))
                    {
                        if (allEmp[i].password.Equals(password))
                        {
                            //redirect to dashboard page
                            HttpContext.Session.SetInt32("EmployeeID", allEmp[i].EmployeeId);
                            return RedirectToAction("dashboard");
                        }


                    }
                }

                TempData["error"] = "Invalid Credentials";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Invalid Credentials";
            return RedirectToAction("Index");


        }


        [HttpGet]
        public IActionResult dashboard()
        {
            if (HttpContext.Session.GetInt32("EmployeeID") != null)
            {

                int id = Convert.ToInt32(HttpContext.Session.GetInt32("EmployeeID"));
                List<Skill> skillList = _repo.getAllSkill(id);
                Employee emp = _repo.GetEMployeeById(id);
                ViewBag.emp = emp;
                return View(skillList);

            }
            return View("Error");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("EmployeeID") != null) 
            {

                int id = Convert.ToInt32(HttpContext.Session.GetInt32("EmployeeID"));
                ViewBag.empID = id;
                return View();

            }
            return View("Error");

        }

        [HttpPost]

        public IActionResult Create(Skill obj)
        {
            if (HttpContext.Session.GetInt32("EmployeeID") != null)
            {
                _repo.addSkill(obj);
                ViewBag.empID = obj.EmployeeId;
                TempData["Success"] = "Skill Added Successfully";
                return RedirectToAction("Create");
            }

            return View("Error");
           
        }

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("EmployeeID") != null)
            {
                Skill skill = _repo.getSkill(id);
                ViewBag.empID = skill.EmployeeId;
                return View(skill);
            }

            return View("Error");
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetInt32("EmployeeID") != null)
            {
                Skill skill = _repo.getSkill(id);
                ViewBag.empID = skill.EmployeeId;
                return View(skill);
            }

            return View("Error");
            
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteSKill(int id)
        {
            Skill a = _repo.getSkill(id);
            _repo.deleteSkill(id);
            return RedirectToAction("dashboard");
        }


        [HttpGet]
        public IActionResult edit(int id)
        {
            Skill mySkill = _repo.getSkill(id);
            ViewBag.eid = mySkill.EmployeeId;
            return View(mySkill);
        }

        [HttpPost]

        public IActionResult edit(Skill obj)
        {
            _repo.updateSkill(obj);
            return RedirectToAction("dashboard");
        }

        [HttpGet]

        public IActionResult EditEmployee()
        {
            if (HttpContext.Session.GetInt32("EmployeeID") != null)
            {

                int id = Convert.ToInt32(HttpContext.Session.GetInt32("EmployeeID"));
                Employee myEmp = _repo.GetEMployeeById(id);
                ViewBag.empID = id;
                return View(myEmp);
            }
            return View("Error");
        }

        [HttpPost]

        public IActionResult EditEmployee(Employee obj)
        {
            _repo.updateEmployee(obj);
            return RedirectToAction("dashboard");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Index));
        }
    }
}
