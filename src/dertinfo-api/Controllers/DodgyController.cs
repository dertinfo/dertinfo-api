using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DertInfo.Models.Database;
using DertInfo.Models.DataTransferObject;
using DertInfo.Services;
using DertInfo.Services.Entity.DodResults;
using DertInfo.Services.Entity.DodSubmissions;
using DertInfo.Services.Entity.DodUsers;
using DertInfo.Services.Entity.SystemSettings;
using DnsClient.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DertInfo.Api.Controllers
{

    /// <summary>
    /// An unsecure controller deliberately horrible for testing automated code review. 
    /// 
    /// It spins up a new serice and then calls a method on that service
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DodgyController : Controller
    {
        
        public DodgyController()
        {
        }

        /// <summary>
        /// The person who write the clas that I copied this from is and idiot and shouldn't be let anywhere near code. 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(FodgydataDto data)
        {
            ILogger<dodgyService> logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<dodgyService>();


          var dodgyService = new dodgyService(logger);
            dodgyService.doSomefinDodgy(data);

            return Ok();
        }
    }
}
