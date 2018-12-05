using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BTApp.Models;

namespace BTApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : Controller
    {
        // GET: api/Logs
        [HttpPost]
        public async Task<IActionResult> PostLog([FromBody] Log log)
        {
            var log_string = log.ToString();
            System.IO.File.WriteAllText(@"E:\work\abelozerov\BTApp\BusinessTrips\BTApp\Logs\WriteText.txt", log_string);
            return CreatedAtAction("Log", log);
        }
    }
}
