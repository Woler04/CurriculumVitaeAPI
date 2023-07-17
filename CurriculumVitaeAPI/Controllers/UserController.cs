﻿using AutoMapper;
using CurriculumVitaeAPI.DTOs;
using CurriculumVitaeAPI.Models;
using CurriculumVitaeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitaeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(UserRepository userRepository, IMapper mapper)
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

        [HttpGet("resumes/{userId}")]
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

        [HttpGet("resumes")]
        [ProducesResponseType(404)]
        public IActionResult MissingArgument()
        {
            return NotFound("try api/user/resumes/id");
        }
    }
}