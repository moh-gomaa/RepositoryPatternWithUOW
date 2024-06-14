using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.Core.Repositories;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepository<Author> _repo;

        public AuthorsController(IBaseRepository<Author> repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _repo.GetAllAsync());

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
            => Ok(await _repo.GetByIdAsync(id));
    }
}
