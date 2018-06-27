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
            _service = service;
            _configuration = configuration;
        }

        [Route("/{minionName?}")]
        [HttpGet]
        [Produces("text/html")]
        public ActionResult Index(string minionName)
        {
            var httpConnectionFeature = this.HttpContext.Features.Get<IHttpConnectionFeature>();
            var localIpAddress = httpConnectionFeature?.LocalIpAddress;
            var hostName = Environment.MachineName;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Host: ").Append(hostName).Append("<br/>");
            stringBuilder.Append("Minion Type: ").Append(minionName).Append("<br/>");
            stringBuilder.Append("IP: ").Append(localIpAddress).Append("<br/>");
            
            if (string.IsNullOrEmpty(minionName)) 
            {
                stringBuilder.Append("Minion List: ").Append(string.Join(" | ", _service.GetMinionNames()));
            } 
            else 
            {
                stringBuilder.Append(_service.GetMinionByName(minionName));
            }
            
            return Ok(stringBuilder.ToString());
        }

        [Route("/random")]
        [HttpGet]
        [Produces("text/html")]
        public ActionResult Random()
        {
            var httpConnectionFeature = this.HttpContext.Features.Get<IHttpConnectionFeature>();
            var localIpAddress = httpConnectionFeature?.LocalIpAddress;
            var hostName = Environment.MachineName;
            var minionName = _service.GetRandomMinionName();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Host: ").Append(hostName).Append("<br/>");
            stringBuilder.Append("Minion Type: ").Append(minionName).Append("<br/>");
            stringBuilder.Append("IP: ").Append(localIpAddress).Append("<br/>");
            stringBuilder.Append(_service.GetMinionByName(minionName));
            
            return Ok(stringBuilder.ToString());
        }
    }
}
