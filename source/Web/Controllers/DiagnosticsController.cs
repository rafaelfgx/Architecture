using DotNetCore.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Architecture.Web;

[AllowAnonymous]
[ApiController]
[Route("diagnostics")]
public sealed class DiagnosticsController : ControllerBase
{
    [HttpGet("datetime")]
    public DateTime DateTime() => Assembly.GetExecutingAssembly().FileInfo().LastWriteTime;
}
