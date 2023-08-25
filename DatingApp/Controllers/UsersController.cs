using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/users
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUser()
        {
            var users = await _dataContext.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")] // /api/users/2
        public ActionResult<AppUser> GetUser(int id)
        {
            var users = _dataContext.Users.Find(id);


            return users;
            // bisa juga pake return _dataContext.Users.Find(id);
        }

    }

}