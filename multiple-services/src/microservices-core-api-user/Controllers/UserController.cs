using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace microservices_core_api_user.Controllers {
    [ApiController]
    [Route ("[controller]")]
    [Authorize]
    public class UserController : ControllerBase {

        [HttpGet]
        public IActionResult Get () {
            var result = new {
                username = "rud9321",
                userid = "rud",
                name = "Rudra",
                password = "123$"

            };
            return Ok (result);
        }
    }
}