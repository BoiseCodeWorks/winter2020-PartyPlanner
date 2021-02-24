using Party_Planner.Repositories;

namespace Party_Planner.Services
{
  public class PartyMembersService
  {
    private readonly PartyMembersRepository _repo;
    public PartyMembersService(PartyMembersRepository repo)
    {
      _repo = repo;
    }
  }
}