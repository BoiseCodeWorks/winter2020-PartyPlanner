using Party_Planner.Repositories;

namespace Party_Planner.Services
{
  public class PartiesService
  {
    private readonly PartiesRepository _repo;
    public PartiesService(PartiesRepository repo)
    {
      _repo = repo;
    }
  }
}