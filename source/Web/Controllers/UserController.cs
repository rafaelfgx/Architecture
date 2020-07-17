using Architecture.Application;
using Architecture.Model;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Architecture.Web
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public Task<IActionResult> AddAsync(UserModel model)
        {
            return _userService.AddAsync(model).ResultAsync();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteAsync(long id)
        {
            return _userService.DeleteAsync(id).ResultAsync();
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetAsync(long id)
        {
            return _userService.GetAsync(id).ResultAsync();
        }

        [HttpGet("grid")]
        public Task<IActionResult> GridAsync([FromQuery] GridParameters parameters)
        {
            return _userService.GridAsync(parameters).ResultAsync();
        }

        [HttpPatch("{id}/inactivate")]
        public Task InactivateAsync(long id)
        {
            return _userService.InactivateAsync(id);
        }

        [HttpGet]
        public Task<IActionResult> ListAsync()
        {
            return _userService.ListAsync().ResultAsync();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateAsync(UserModel model)
        {
            return _userService.UpdateAsync(model).ResultAsync();
        }
    }
}
