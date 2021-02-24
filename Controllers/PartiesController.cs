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

    public PartiesController(PartiesService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<Party> Get()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]  // NOTE '{}' signifies a var parameter
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


    [HttpPost]
    public ActionResult<Party> Create([FromBody] Party newProd)
    {
      try
      {
        Party newParty = _service.Create(newProd)
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