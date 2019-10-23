using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReview.API.Domain.Models;
using MovieReview.API.Domain.Services;

namespace MovieReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //GET: api/Users
       [HttpGet]
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            return users;
        }


        /// <summary>
        /// Updates an existing product according to an identifier.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <param name="resource">Product data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] float rating)
        {  
            var result = await _userService.UpdateAsync(id, rating);

            if (result is null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
