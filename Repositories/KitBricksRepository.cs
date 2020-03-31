using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using legokit.Models;

namespace legokit.Repositories
{
  public class KitBricksRepository
  {
    private readonly IDbConnection _db;
    public KitBricksRepository(IDbConnection db)
    {
      _db = db;
    }


    // internal Brick Get(int id)
    // {
    //   string sql = "SELECT * FROM bricks WHERE id = @id";
    //   return _db.QueryFirstOrDefault<Brick>(sql, new { id });
    // }

    internal IEnumerable<Brick> Get()
    {
      string sql = "SELECT * FROM Bricks";
      return _db.Query<Brick>(sql);
    }

    // public IEnumerable<KitPart> getBricksByKitId(int kitId)
    // {
    //   string sql = @"
    //             SELECT *, b.name as brickName, k.name as kitName FROM kitbricks kb
    //             INNER JOIN bricks b ON b.id = kb.brickId
    //             INNER JOIN kits k on k.id = kb.kitId
    //             WHERE (kb.kitId = @kitId)
    //             ";

    //   return _db.Query<KitPart>(sql, new { kitId });
    // }

    public IEnumerable<KitBrick> getBricksByKitId(int kitId)
    {
      string sql = @"
                SELECT * FROM kitbricks kb
                WHERE (kb.kitId = @kitId)
                ";

      return _db.Query<KitBrick>(sql, new { kitId });
    }

    // string sql = @"
    //             SELECT * FROM kitbricks kb
    //             WHERE (kb.kitId = @kitId)
    //             ";


    // INNER JOIN bricks b ON b.id = kb.brickId
    // JOIN kits k ON k.id = kb.kitId



    internal void Delete(int id)
    {
      string sql = "DELETE FROM kitbricks WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    internal int Create(KitBrick newBrick)
    {
      string sql = @"
                INSERT INTO kitbricks
                (brickId, kitId, quantity)
                VALUES
                (@BrickId, @KitId, @Quantity);
                SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newBrick);
    }
  }
}