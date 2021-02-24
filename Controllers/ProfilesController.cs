using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Party_Planner.Models;
using Party_Planner.Services;

namespace Party_Planner.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _service;
    private readonly PartiesService _ps;

    public ProfilesController(ProfilesService service, PartiesService ps)
    {
      _service = service;
      _ps = ps;
    }

    [HttpGet("{id}")]
    public ActionResult<Profile> Get(string id)
    {
      try
      {
        Profile profile = _service.GetProfileById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet(("{id}/parties"))]
    [Authorize]
    public ActionResult<IEnumerable<PartyPartyMemberViewModel>> GetParties(string id)
    {
      try
      {
        IEnumerable<PartyPartyMemberViewModel> parties = _ps.GetByProfileId(id);
        return Ok(parties);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}