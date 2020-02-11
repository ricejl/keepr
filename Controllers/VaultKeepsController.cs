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
        private readonly VaultsService _vs;
        public VaultKeepsController(VaultKeepsService vks, VaultsService vs)
        {
            _vks = vks;
            _vs = vs;
        }

        [HttpGet("{vaultId}/keeps")]
        [Authorize]
        public ActionResult<IEnumerable<Keep>> GetById(int vaultId)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // send to vault service to check if vault id is valid and belongs to user
                var vault = _vs.GetById(vaultId, userId);
                return Ok(_vks.GetById(vault));
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