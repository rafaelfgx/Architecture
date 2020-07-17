using DotNetCore.AspNetCore;
using DotNetCore.Logging;
using Microsoft.Extensions.Hosting;

namespace Architecture.Web
{
    public static class Program
    {
        public static void Main()
        {
            Host.CreateDefaultBuilder().UseSerilog().Run<Startup>();
        }
    }
}
