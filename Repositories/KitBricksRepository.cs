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

    public IEnumerable<KitBrick> getBricksByKitId(int kitId)
    {
      string sql = @"
                SELECT * FROM kitbricks kb
                WHERE (kb.kitId = @kitId)
                ";

      return _db.Query<KitBrick>(sql, new { kitId });
    }
    // INNER JOIN bricks b ON b.id = kb.brickId
    // JOIN kits k ON k.id = kb.kitId

    // SELECT * FROM kitbricks kb WHERE kitId = @kitId
    // JOIN bricks b on b.id = kb.brickId
    // JOIN kits k on k.id = kb.kitId
    // WHERE kb.kitId = @kitId


    internal void Delete(int id)
    {
      string sql = "DELETE FROM bricks WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    internal int Create(KitBrick newBrick)
    {
      string sql = @"
                INSERT INTO bricks
                (name)
                VALUES
                (@Name);
                SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newBrick);
    }
  }
}