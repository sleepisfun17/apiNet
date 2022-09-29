using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardCodeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return StatusCode(200, "Langsung get lewat akses api/hardcode");
        }

        [HttpGet]
        [Route("GetHardCode")]
        public ActionResult GetHardCode()
        {
            return StatusCode(200, "akses melalui api/hardcode/gethardcode");
        }
    }
}
