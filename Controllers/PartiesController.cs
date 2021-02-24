using Microsoft.AspNetCore.Mvc;
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
  }
}