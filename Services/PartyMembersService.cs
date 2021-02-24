using System;
using Party_Planner.Models;
using Party_Planner.Repositories;
using Party_Planner.Exceptions;

namespace Party_Planner.Services
{
  public class PartyMembersService
  {
    private readonly PartyMembersRepository _repo;
    private readonly PartiesRepository _pr;
    public PartyMembersService(PartyMembersRepository repo, PartiesRepository pr)
    {
      _repo = repo;
      _pr = pr;
    }

    internal void Create(PartyMember pm, string id)
    {
      Party party = _pr.GetById(pm.PartyId);
      if (party == null)
      {
        throw new Exception("Invalid Id");
      }
      if (party.CreatorId != id)
      {
        throw new NotAuthorized("Not The Owner of this Party");
      }
      _repo.Create(pm);
    }

    internal void Delete(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
    }
  }
}