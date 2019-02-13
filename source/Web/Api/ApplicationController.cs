using DotNetCore.AspNetCore;
using DotNetCoreArchitecture.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Web
{
    [ApiController]
    [RouteController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet]
        public Task<ApplicationModel> GetAsync()
        {
            var applicationModel = new ApplicationModel();

            return Task.FromResult(applicationModel);
        }
    }
}
