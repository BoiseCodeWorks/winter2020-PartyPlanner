using System;
using System.Collections.Generic;
using Party_Planner.Models;
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
    internal IEnumerable<Party> GetAll()
    {
      // FIXME Should not be able to get any and all parties
      return _repo.GetAll();
    }

    internal Party GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Party Create(Party newProd)
    {
      return _repo.Create(newProd);
    }

    internal Party Edit(Party updated)
    {
      var data = GetById(updated.Id);
      updated.Name = updated.Name != null ? updated.Name : data.Name;
      return _repo.Edit(updated);
    }

    internal Party Delete(int id)
    {
      var data = GetById(id);
      _repo.Delete(id);
      return data;
    }
  }
}