using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Features.Minions
{
    public class MinionsController : Controller
    {
        readonly IMinionService _service;
        readonly IConfiguration _configuration;

        public MinionsController(IMinionService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [Route("/{minionName?}")]
        [HttpGet]
        [Produces("text/html")]
        public ActionResult Index(string minionName)
        {
            this.FillViewBag(minionName, _service.GetMinionByName(minionName));
            return View("Minions", _service.GetMinionNames());
        }

        [Route("/random")]
        [HttpGet]
        [Produces("text/html")]
        public ActionResult Random()
        {
            var minionName = _service.GetRandomMinionName();
            this.FillViewBag(minionName, _service.GetMinionByName(minionName));
            return View("Minions");
        }

        void FillViewBag(string minionName, string asciiArt)
        {
            var httpConnectionFeature = this.HttpContext.Features.Get<IHttpConnectionFeature>();
            var localIpAddress = httpConnectionFeature?.LocalIpAddress;
            var hostName = Environment.MachineName;

            this.ViewBag.HostName = hostName;
            this.ViewBag.IpAddress = localIpAddress;

            if (!string.IsNullOrEmpty(minionName))
            {
                this.ViewBag.MinionType = minionName;
                this.ViewBag.AsciiArt = asciiArt;
            }
        }
    }
}
