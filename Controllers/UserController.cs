using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Data;
using Library.DTOs;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    // /user
    [Route("user")]
    [ApiController]
    [Authorize(Policy = Policies.User)]
    public class UserController : ControllerBase
    {


        private readonly IUserRepo _repository;        //Get Repository
        
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly int currentUserId;
        
        public UserController(IUserRepo repository, IHttpContextAccessor _httpContextAccessor)
        {
            _repository = repository;
            httpContextAccessor = _httpContextAccessor;
            currentUserId = Int32.Parse(httpContextAccessor.HttpContext.User.FindFirst("Id_").Value);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadBookDTO>>> ShowBooks()
        { 
            return Ok(await _repository.ShowBooks());
        }


        [HttpGet("books")]
        public async Task<ActionResult<ProfileDTO>> ShowProfiles()
        { 
            return Ok(await _repository.ShowProfile(currentUserId));
        }

        [HttpPost("/take")]
        public async Task<ActionResult> TakeBook(int copy_id)
        {
            await _repository.Take_Book(currentUserId, copy_id);
            return Ok();
        }



        [HttpPost("/back")]
        public async Task<ActionResult> BackBook(int copy_id)
        {
            await _repository.Back_Book(currentUserId, copy_id);
            return Ok();
        }
    }

}

