using apiNet.Logics;
using apiNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Security.Claims;

namespace apiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpGet]
        [Route("GenerateToken")]
        public ActionResult GenerateToken([FromBody] User user)
        {
            string jwtToken = "";
            // logic to create token
            
            return Ok(jwtToken);
        }

        [HttpGet]
        [Route("ValidateToken")]
        [Authorize]
        public ActionResult ValidateToken()
        {
            return Ok("Congrats, your token is right!");
        }
    }
}
