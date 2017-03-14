using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdiApi.Models;

namespace UdiApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("getall")]
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("get/{id}", Name = "GetUser")]
        public IActionResult GetById(long id)
        {
            var user = _userRepository.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _userRepository.Add(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(long id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            var editUser = _userRepository.Find(id);
            if (editUser == null)
            {
                return NotFound();
            }

            editUser.Birthdate = user.Birthdate;
            editUser.Name = user.Name;

            _userRepository.Update(editUser);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("update/")]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var editUser = _userRepository.Find(user.Id);
            if (editUser == null)
            {
                return NotFound();
            }

            editUser.Birthdate = user.Birthdate;
            editUser.Name = user.Name;

            _userRepository.Update(editUser);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpDelete("remove/{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _userRepository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            _userRepository.Remove(id);
            return new NoContentResult();
        }

    }
}
