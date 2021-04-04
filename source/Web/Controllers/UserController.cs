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
    public sealed class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Add(UserModel model)
        {
            return _userService.AddAsync(model).ApiResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return _userService.DeleteAsync(id).ApiResult();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return _userService.GetAsync(id).ApiResult();
        }

        [HttpGet("grid")]
        public IActionResult Grid([FromQuery] GridParameters parameters)
        {
            return _userService.GridAsync(parameters).ApiResult();
        }

        [HttpPatch("{id}/inactivate")]
        public Task Inactivate(long id)
        {
            return _userService.InactivateAsync(id);
        }

        [HttpGet]
        public IActionResult List()
        {
            return _userService.ListAsync().ApiResult();
        }

        [HttpPut("{id}")]
        public IActionResult Update(UserModel model)
        {
            return _userService.UpdateAsync(model).ApiResult();
        }
    }
}
