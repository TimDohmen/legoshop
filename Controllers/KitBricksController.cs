using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legokit.Models;
using legokit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lego.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KitBricksController : ControllerBase
  {
    private readonly KitBricksService _kbs;

    public KitBricksController(KitBricksService kbs)
    {
      _kbs = kbs;
    }



    // GET api/values/5
    //kit id get all bricks for a single set

    // [HttpGet("{kitId}")]
    // public ActionResult<KitPart> Get(int kitId)
    // {
    //   try
    //   {
    //     return Ok(_kbs.GetBricks(kitId));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpGet("{kitId}")]
    public ActionResult<KitBrick> Get(int kitId)
    {
      try
      {
        return Ok(_kbs.GetBricks(kitId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    // POST api/values
    [HttpPost]
    public ActionResult<Brick> Post([FromBody] KitBrick newBrick)
    {
      try
      {
        return Ok(_kbs.Create(newBrick));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_kbs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

