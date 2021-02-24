using System.Data;

namespace Party_Planner.Repositories
{
  public class PartyMembersRepository
  {
    private readonly IDbConnection _db;

    public PartyMembersRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}