using System;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;
        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<String> Create([FromBody] VaultKeeps newData)
        {
            try
            {
                newData.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _vks.Create(newData);
                return Ok("Success");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/removeKeep")]
        [Authorize]
        public ActionResult<String> Edit([FromBody] VaultKeeps vk)
        {
            try
            {
                vk.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Delete(vk));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}