using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
      SELECT * FROM parties";
      return _db.Query<Party>(sql);
    }


    // REVIEW[epic=Populate] add the creator to the object
    internal Party GetById(int id)
    {
      string sql = @" 
      SELECT 
      part.*,
      pr.*
      FROM parties part
      JOIN profiles pr ON part.creatorId = pr.id
      WHERE id = @id";
      return _db.Query<Party, Profile, Party>(sql, (party, profile) =>
      {
        party.Creator = profile;
        return party;
      }, new { id }, splitOn: "id").FirstOrDefault();

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

    // REVIEW[epic=many-to-many] This sql will add the relationship id to a Party, as the PartyPartyMemberViewModel
    // REVIEW[epic=Populate] and get the creator
    internal IEnumerable<PartyPartyMemberViewModel> GetPartiesByProfileId(string id)
    {
      string sql = @"
      SELECT
      part.*,
      pm.id as PartyMemberId,
      pr.*
      FROM partymembers pm
      JOIN parties part ON pm.partyId == part.id
      JOIN profiles pr ON part.creatorId = pr.id
      WHERE memberId = @id
      ";
      return _db.Query<PartyPartyMemberViewModel, Profile, PartyPartyMemberViewModel>(sql, (party, profile) =>
      {
        party.Creator = profile;
        return party;
      }
        , new { id }, splitOn: "id");
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM parties WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}