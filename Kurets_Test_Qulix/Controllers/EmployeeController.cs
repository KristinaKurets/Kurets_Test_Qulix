using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurets_Test_Qulix.Models;
using Kurets_Test_Qulix.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Kurets_Test_Qulix.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IService<Employee> _service;

        public EmployeeController(IService<Employee> service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Add the employer.
        /// </summary>
        /// <param name="employee"> Added person.</param>
        /// <returns>On success returns 204 status code.</returns>
        [HttpPost]
        [Route("add")]
        public ActionResult AddEmployee(Employee employee)
        {
            _service.Add(employee);
            return NoContent();
        }


        /// <summary>
        /// Edit the employer.
        /// </summary>
        /// <param name="employee"> Edited person.</param>
        /// <returns>On success returns 204 status code.</returns>
        [HttpPost]
        [Route("edit")]
        public ActionResult EditEmployee(Employee employee)
        {
            _service.Edit(employee);
            return NoContent();
        }

        /// <summary>
        /// Delete the employer.
        /// </summary>
        /// <param name="employee"> Deleted person.</param>
        /// <returns>On success returns 204 status code.</returns>
        [HttpPost]
        [Route("delete")]
        public ActionResult DeleteEmployee(Employee employee)
        {
            _service.Delete(employee);
            return NoContent();
        }
    }
}
