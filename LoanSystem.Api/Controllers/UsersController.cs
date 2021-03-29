using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using LoanSystem.Api.Errors;
using LoanSystem.Api.Responses;
using LoanSystem.Core.DTOs;
using LoanSystem.Core.Entities;
using LoanSystem.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace LoanSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public readonly IService<User> _userService;
        public readonly IMapper _mapper;
        public UsersController(IService<User> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.Get();
            var usersDto = _mapper.Map<List<UserDto>>(users);
            var response = new ApiResponse<List<UserDto>>(usersDto,HttpStatusCode.OK);
            return Ok(response);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetOne(id);
            if( user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDto>(user);

            return Ok(new ApiResponse<UserDto>(userDto, HttpStatusCode.OK));
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.Post(user);
            userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto, HttpStatusCode.Created);

            return CreatedAtAction(nameof(Get), new { id = userDto.Id }, response);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]  UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = id;

            var result = await _userService.Put(user);

            return result ? NoContent(): null;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            return result ? NoContent() : null;

        }
    }
}
