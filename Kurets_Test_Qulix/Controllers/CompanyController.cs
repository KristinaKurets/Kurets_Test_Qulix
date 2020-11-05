using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurets_Test_Qulix.Models;
using Kurets_Test_Qulix.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Kurets_Test_Qulix.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IService<Company> _service;
        public CompanyController(IService<Company> service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Add the company.
        /// </summary>
        /// <param name="company"> Added company.</param>
        /// <returns>On success returns 204 status code.</returns>
        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            _service.Add(company);
            return NoContent();
        }


        /// <summary>
        /// Edit the company.
        /// </summary>
        /// <param name="company"> Edited company.</param>
        /// <returns>On success returns 204 status code.</returns>
        [HttpPost]
        public ActionResult EditCompany(Company company)
        {
            _service.Edit(company);
            return NoContent();
        }

        /// <summary>
        /// Delete the company.
        /// </summary>
        /// <param name="company"> Deleted company.</param>
        /// <returns>On success returns 204 status code.</returns>
        [HttpPost]
        [Route("delete")]
        public ActionResult DeleteCompany(Company company)
        {
            _service.Delete(company);
            return NoContent();
        }
    }
}
