using Party_Planner.Services;

namespace Party_Planner.Controllers
{
  public class PartyMembersController
  {
    private readonly PartyMembersService _service;

    public PartyMembersController(PartyMembersService service)
    {
      _service = service;
    }
  }
}