using System.Collections.Generic;
using System.Data;
using Dapper;
using Party_Planner.Models;

namespace Party_Planner.Repositories
{
  public class PartiesRepository
  {
    private readonly IDbConnection _db;

    public PartiesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Party> GetAll()
    {
      string sql = @"
      SELECT * FROM products parties";
      return _db.Query<Party>(sql);
    }

    internal Party GetById(int id)
    {
      string sql = @" 
      SELECT * FROM products parties WHERE id = @id";
      return _db.QueryFirstOrDefault<Party>(sql, new { id });
    }

    internal Party Create(Party newParty)
    {
      string sql = @"
      INSERT INTO parties 
      (creatorId, name) 
      VALUES 
      (@CreatorId, @Name);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newParty);
      newParty.Id = id;
      return newParty;
    }

    internal Party Edit(Party updated)
    {
      string sql = @"
        UPDATE parties
        SET
         name = @Name
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM products WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}