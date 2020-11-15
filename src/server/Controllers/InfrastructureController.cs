using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Nekoma.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfrastructureController : ControllerBase
    {
        private readonly ILogger<InfrastructureController> _logger;

        public InfrastructureController(ILogger<InfrastructureController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public Infrastructure Get()
        {
            return new Infrastructure
            {
                IsRunningInContainer = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") is object,
                FrameworkDescription = RuntimeInformation.FrameworkDescription,
                OSDescription = RuntimeInformation.OSDescription
            };
        }
    }
}