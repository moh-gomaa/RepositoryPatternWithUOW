using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core.Consts;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.Core.Repositories;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _repo;

        public BooksController(IBaseRepository<Book> repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _repo.GetAllAsync(new string[] {"Author"}, x => x.Id, OrderBy.Descending));

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int Id)
            => Ok(await _repo.GetByIdAsync(Id));

        [HttpGet("FindFirstAsync")]
        public async Task<IActionResult> FindFirstAsync(string serchQuery)
        {
            return Ok(await _repo.FindFirstAsync(x => x.Title.Contains(serchQuery), new string[] { "Author" }));
        }
        
        [HttpGet("FindAllAsync")]
        public async Task<IActionResult> FindAllAsync(string serchQuery)
        {
            return Ok(await _repo.FindAllAsync(x => x.Title.Contains(serchQuery), new string[] { "Author" }, x => x.Id, OrderBy.Descending, true, 0, 2));
        }
    }
}
