using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServiceImp _userService;

        public UserController(UserServiceImp userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var data = _userService.GetAllUser();
            return Ok(data);
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(string id)
        {
            var data = _userService.GetUserById(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }


    }
}
