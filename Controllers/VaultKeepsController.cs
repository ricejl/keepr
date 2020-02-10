using System;
using System.Collections.Generic;
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

        // TODO get keeps by vault id
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<IEnumerable<Keep>> GetById([FromBody] Vault v)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.GetById(v, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<String> Create([FromBody] VaultKeep newData)
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
        public ActionResult<String> Edit([FromBody] VaultKeep vk)
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