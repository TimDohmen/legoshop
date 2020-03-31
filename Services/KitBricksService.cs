using System;
using System.Collections.Generic;
using legokit.Models;
using legokit.Repositories;

namespace legokit.Services
{
  public class KitBricksService
  {
    private readonly KitBricksRepository _repo;
    private readonly KitsRepository _krepo;
    public KitBricksService(KitBricksRepository repo, KitsRepository krepo)
    {
      _repo = repo;
      _krepo = krepo;
    }

    public IEnumerable<KitBrick> GetBricks(int kitId)
    {
      Kit exists = _krepo.Get(kitId);
      if (exists == null) { throw new Exception("Invalid Id Homie"); }
      return _repo.getBricksByKitId(kitId);
    }

    public IEnumerable<Brick> Get()
    {
      return _repo.Get();
    }

    public KitBrick Create(KitBrick newBrick)
    {
      int id = _repo.Create(newBrick);
      newBrick.Id = id;
      return newBrick;
    }

    public object Delete(int id)
    {
      _repo.Delete(id);
      return "Successfully Booted";
    }
  }
}