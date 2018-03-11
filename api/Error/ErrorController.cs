
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Error
{
    public class ErrorController : Controller
    {

        [Route("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task Error()
        {
            this.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            this.HttpContext.Response.ContentType = "text/html";
            var ex = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (ex != null)
            {
                var err = $"<h2>Error: {ex.Error.Message}</h2><br/><h3>${this.HttpContext.TraceIdentifier}</h3><br/>{ex.Error.StackTrace}";
                await this.HttpContext.Response.WriteAsync(err).ConfigureAwait(false);
            }
            else 
            {
                var err = $"<h3>Trace: {this.HttpContext.TraceIdentifier}</h3>";
                await this.HttpContext.Response.WriteAsync(err).ConfigureAwait(false);
            }
        }
    }
}











                            