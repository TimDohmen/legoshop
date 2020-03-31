using System;
using System.Data;

namespace legokit.Repositories
{
  public class BricksRepository
  {
    private readonly IDbConnection _db;
    public BricksRepository(IDbConnection db)
    {
      _db = db;
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }

    internal int Create(Brick newBrick)
    {
      throw new NotImplementedException();
    }

    internal Brick Get(int id)
    {
      throw new NotImplementedException();
    }

    internal System.Collections.Generic.IEnumerable<Brick> Get()
    {
      throw new NotImplementedException();
    }
  }
}