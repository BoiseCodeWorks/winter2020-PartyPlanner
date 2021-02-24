using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Party_Planner.Models;
using Party_Planner.Services;

namespace Party_Planner.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PartiesController : ControllerBase
  {
    private readonly PartiesService _service;
    private readonly ProfilesService _ps;

    public PartiesController(PartiesService service, ProfilesService ps)
    {
      _service = service;
      _ps = ps;
    }

    [HttpGet("{id}")]
    public ActionResult<Party> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/members")]
    public ActionResult<Party> GetMembers(int id)
    {
      try
      {
        return Ok(_ps.GetMembersByPartyId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<Party> Create([FromBody] Party newProd)
    {
      try
      {
        Party newParty = _service.Create(newProd);
        return Ok(newParty);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Party> Edit([FromBody] Party updated, int id)
    {
      try
      {
        Party edited = _service.Edit(updated);
        return Ok(edited);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Party> Delete(int id)
    {
      try
      {
        Party deleted = _service.Delete(id);
        return Ok(deleted);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}