using Microsoft.Extensions.Logging;

namespace Architecture.Application.Demo
{
    public class DemoService : IDemoService
    {
        private readonly ILogger<DemoService> _logger;

        public DemoService(ILogger<DemoService> logger)
        {
            _logger = logger;
        }

        public void DemoMethod(string param1)
        {

        }
    }
}
