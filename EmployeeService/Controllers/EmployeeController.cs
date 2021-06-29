using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeService.Models;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // api/product
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var data = _repository.GetAllEmployees();
            return Ok(data);
        }

        // api/product/id
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var data = _repository.GetEmployeeById(id);
            if (data == null)
                return NotFound("No recprd found with id: " + id);
            return Ok(data);
        }

        // api/product - post
        // http://localhost:1234/product/1
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(Employee employee)
        {
            var data = _repository.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                "/" + HttpContext.Request.Path + "/" + employee.Id, data);
        }
    }
}
