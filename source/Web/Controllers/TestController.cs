using Architecture.Application.Demo;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web.Controllers
{
    public class TestController : ControllerBase
    {
        private readonly IDemoService _demoService;
        private readonly ILogger<TestController> _logger;

        public TestController(IDemoService demoService, ILogger<TestController> logger)
        {
            _demoService = demoService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _demoService.DemoMethod("");
            _logger.LogWarning("Warning {param1}, {param2}, {param3}",
                "p1",
                "p2");

            return Ok();
        }
    }
}
