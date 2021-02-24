using System;
using Microsoft.AspNetCore.Mvc;
using Party_Planner.Models;
using Party_Planner.Services;

namespace Party_Planner.Controllers
{
  public class PartyMembersController : ControllerBase
  {
    private readonly PartyMembersService _service;

    public PartyMembersController(PartyMembersService service)
    {
      _service = service;
    }

    //REVIEW[epic=many-to-many] Which methods are actually needed here?
    [HttpPost]
    public ActionResult<string> Create([FromBody] PartyMember pm)
    {
      try
      {
        _service.Create(pm);
        return Ok("success");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Delete 
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _service.Delete(id);
        return Ok("success");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}