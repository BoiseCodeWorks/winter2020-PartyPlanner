using System;
using Party_Planner.Models;
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

    internal void Create(PartyMember pm)
    {
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