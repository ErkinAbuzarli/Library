using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Data;
using Library.DTOs;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    // /admin
    [Route("admin")]
    [ApiController]
    [Authorize(Policy = Policies.Admin)]

    public class AdminController : ControllerBase
    {


        private readonly IAdminRepo _repository;        //Get Repository
        private readonly ILogin _login;       



        public AdminController(IAdminRepo repository, ILogin login)
        {
            _repository = repository;
            _login = login;
        }






        //GET METHODS START

        // /admin/books
        [HttpGet("books")]
        public async Task<ActionResult<IEnumerable<ReadBookDTO>>> ShowBooks()
        { 
            return Ok(await _repository.GetBooks());
        }

        // /admin/categories
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<Category>>> ShowCategories()
        {
            return Ok(await _repository.GetCategories());
        }

        // /admin/copies
        [HttpGet("copies")]
        public async Task<ActionResult<IEnumerable<Copy>>> ShowCopies()
        {
            return Ok(await _repository.GetCopies());
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> ShowUsers()
        {
            return Ok(await _repository.GetUsers());
        }

        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<History>>> ShowHistory()
        {
            return Ok(await _repository.GetHistory());
        }

















        // GET METHODS END



        [HttpPost("books")]

        public async Task<ActionResult> AddBook(PostBookDTO NewBook)
        {
            await _repository.AddBook(NewBook);
            return NoContent();
        }


        [HttpPost("categories")]

        public async Task<ActionResult> AddCategory(PostCategoryDTO NewCategory)
        {
            await _repository.AddCategory(NewCategory);
            return NoContent();
        }

        [HttpPost("copies")]

        public async Task<ActionResult> AddCopy(PostCopyDTO NewCopy)
        {
            await _repository.AddCopy(NewCopy);
            return NoContent();
        }

        [HttpPost("users")]
        [AllowAnonymous]
        public async Task<ActionResult> AddUser(PostUserDTO NewUser)
        {
            await _repository.AddUser(NewUser);
            return NoContent();
        }


















        [HttpDelete("books/{id}")]

        public async Task<ActionResult> DeleteBook(int id)
        {
            await _repository.DeleteBook(id);
            return Ok();
        }


        [HttpDelete("copies/{id}")]

        public async Task<ActionResult> DeleteCopy(int id)
        {
            await _repository.DeleteCopy(id);
            return Ok();
        }


        [HttpDelete("users/{id}")]

        public async Task<ActionResult> DeleteUser(int id)
        {
            await _repository.DeleteUser(id);
            return Ok();
        }


        [HttpDelete("categories/{id}")]

        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _repository.DeleteCategory(id);
            return Ok();
        }





















        [HttpPatch("books/{id}")]

        public async Task<ActionResult> UpdateBooks(int id, JsonPatchDocument<PostBookDTO> patchDoc)
        {
            var RepoToDto = await _repository.FindAndMapBook(id);

            patchDoc.ApplyTo(RepoToDto, ModelState);
            if(!TryValidateModel(RepoToDto)) return ValidationProblem(ModelState);

            await _repository.MapAndSaveBook(RepoToDto, await _repository.GetBookById(id));

            return NoContent();
        }


        [HttpPatch("users/{id}")]

        public async Task<ActionResult> UpdateUsers(int id, JsonPatchDocument<PostUserDTO> patchDoc)
        {
            var RepoToDto = await _repository.FindAndMapUser(id);

            patchDoc.ApplyTo(RepoToDto, ModelState);
            if(!TryValidateModel(RepoToDto)) return ValidationProblem(ModelState);

            await _repository.MapAndSaveUser(RepoToDto, await _repository.GetUserById(id));

            return NoContent();
        }


        [HttpPatch("copies/{id}")]

        public async Task<ActionResult> UpdateCopies(int id, JsonPatchDocument<PostCopyDTO> patchDoc)
        {
            var RepoToDto = await _repository.FindAndMapCopy(id);

            patchDoc.ApplyTo(RepoToDto, ModelState);
            if(!TryValidateModel(RepoToDto)) return ValidationProblem(ModelState);

            await _repository.MapAndSaveCopy(RepoToDto, await _repository.GetCopyById(id));

            return NoContent();
        }

        [HttpPatch("categories/{id}")]

        public async Task<ActionResult> UpdateCategories(int id, JsonPatchDocument<PostCategoryDTO> patchDoc)
        {
            var RepoToDto = await _repository.FindAndMapCategory(id);

            patchDoc.ApplyTo(RepoToDto, ModelState);
            if(!TryValidateModel(RepoToDto)) return ValidationProblem(ModelState);

            await _repository.MapAndSaveCategory(RepoToDto, await _repository.GetCategoryById(id));

            return NoContent();
        }












        [HttpPost("search/{where}")]
        public async Task<ActionResult> Search(string where, PostSearchDTO str)
        {
            switch (where)
            {
                case "books":
                    return Ok(await _repository.SearchBooks(str.SearchBy, str.SearchString));
                case "copies":
                    return Ok(await _repository.SearchCopies(str.SearchBy, str.SearchString));
                case "categories":
                    return Ok(await _repository.SearchCategories(str.SearchBy, str.SearchString));
                case "users":
                    return Ok(await _repository.SearchUsers(str.SearchBy, str.SearchString));
                case "history":
                    return Ok(await _repository.SearchHistory(str.SearchBy, str.SearchString));
                default:
                    return NotFound();
            }
            
        }










        [HttpPost("sort/{where}")]
        public async Task<ActionResult> Sort(string where, PostSortDTO str)
        {
            switch (where)
            {
                case "books":
                    return Ok(await _repository.SortBooks(str.OrderBy, str.Asc));
                case "copies":
                    return Ok(await _repository.SortCopies(str.OrderBy, str.Asc));
                case "categories":
                    return Ok(await _repository.SortCategories(str.OrderBy, str.Asc));
                case "users":
                    return Ok(await _repository.SortUsers(str.OrderBy, str.Asc));
                case "history":
                    return Ok(await _repository.SortHistory(str.OrderBy, str.Asc));
                default:
                    return NotFound();
            }
            
        }


        [HttpPost("filter/")]
        public async Task<ActionResult> Filter(PostFilterDTO str)
        {
            return Ok(await _repository.FilterHistory(str.Option, str.MinDate, str.MaxDate));
        }
    }
}
  