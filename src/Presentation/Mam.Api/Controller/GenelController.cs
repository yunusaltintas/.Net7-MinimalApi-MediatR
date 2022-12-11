using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Mam.Api.Controller
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class GenelController : ControllerBase
    {
        public GenelController()
        {

        }


        [HttpGet]
        [OutputCache(PolicyName = "Custom")]
        public ActionResult Index()
        {

            return Ok(DateTime.Now);
        }
    }
}
