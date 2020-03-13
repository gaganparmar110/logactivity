using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FBRxweb.Domain.LogActivitieModule;
using FBRxweb.Models.Main;
using RxWeb.Core.AspNetCore;
using RxWeb.Core.Security.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace FBRxweb.Api.Controllers.LogActivitieModule
{
    [ApiController]
    [Route("api/[controller]")]
	[AllowAnonymous]
	public class LogActivitiesController : BaseDomainController<LogActivity, LogActivity>

    {
        public LogActivitiesController(ILogActivityDomain domain):base(domain) {}

    }
}
