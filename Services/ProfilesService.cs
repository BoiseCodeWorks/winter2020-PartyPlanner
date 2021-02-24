using System;
using System.Collections.Generic;
using Party_Planner.Models;
using Party_Planner.Repositories;

namespace Party_Planner.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }
    internal Profile GetOrCreateProfile(Profile userInfo)
    {
      Profile profile = _repo.GetById(userInfo.Id);
      if (profile == null)
      {
        return _repo.Create(userInfo);
      }
      return profile;
    }

    internal Profile GetProfileById(string id)
    {
      Profile profile = _repo.GetById(id);
      if (profile == null)
      {
        throw new Exception("Invalid Id");
      }
      return profile;
    }

    internal IEnumerable<Profile> GetMembersByPartyId(int id)
    {
      return _repo.GetByPartyId(id);
    }
  }
}