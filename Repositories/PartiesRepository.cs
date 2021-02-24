using System.Data;

namespace Party_Planner.Repositories
{
  public class PartiesRepository
  {
    private readonly IDbConnection _db;

    public PartiesRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}