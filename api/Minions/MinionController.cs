using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Minions
{
    public class MinionController : Controller
    {
        readonly IMinionService _service;
        readonly IConfiguration _configuration;

        public MinionController(IMinionService service, IConfiguration configuration)
        {
            this._service = service;
            this._configuration = configuration;
        }

        [Route("/")]
        [HttpGet]
        [Produces("text/html")]
        public IActionResult Index()
        {
            var httpConnectionFeature = this.HttpContext.Features.Get<IHttpConnectionFeature>();
            var localIpAddress = httpConnectionFeature?.LocalIpAddress;
            var hostName = Environment.MachineName;
            var appName = this._configuration["APP_NAME"];
            var version = this._configuration["APP_VERSION"];

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Host: ").Append(hostName).Append("<br/>");
            stringBuilder.Append("Minion Type: ").Append(appName).Append("<br/>");
            stringBuilder.Append("IP: ").Append(localIpAddress).Append("<br/>");
            stringBuilder.Append("Version: ").Append(version).Append("<br/>");
            stringBuilder.Append(this._service.GetMinionByName(appName));
            
            return Ok(stringBuilder.ToString());
        }
    }
}
