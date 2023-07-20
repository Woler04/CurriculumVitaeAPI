using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Models;
using CurriculumVitaeAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userId)
        {
            if (!_userRepository.isUserExcisting(userId))
            {
                return NotFound();
            }

            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);
        }

        [HttpGet("{userId}/resumes")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetResumesByUser(int userId)
        {
            if (!_userRepository.isUserExcisting(userId))
            {
                return NotFound();
            }

            var resumes = _mapper.Map<List<UserDto>>(_userRepository.GetResumesByUser(userId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(resumes);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest();
            }

            var user = _userRepository.GetUsers()
                .Where(r => r.Username.Trim().ToLower() == userCreate.Username.TrimEnd().ToLower()).FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "This username is taken");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userMap = _mapper.Map<User>(userCreate);
            userMap.Id = 0;

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Cannot Save");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int userId, [FromBody] UserDto userUpdate)
        {
            if (userUpdate == null)
            {
                return BadRequest();
            }

            if (!_userRepository.isUserExcisting(userId))
            {
                return NotFound();
            }

            if (userId != userUpdate.Id)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userMap = _mapper.Map<User>(userUpdate);

            if (!_userRepository.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Can not update");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }
        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult DeleteUser(int userId)
        {
            if (!_userRepository.isUserExcisting(userId))
            {
                return NotFound();
            }

            var userDelete = _userRepository.GetUser(userId);


            //delete if has any connections
            if (userDelete.Resumes != null)
            {
                foreach (var resume in userDelete.Resumes)
                {
                    //resume Delete
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_userRepository.DeleteUser(userDelete))
            {
                ModelState.AddModelError("", "Can not delete");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted");
        }
    }
}
