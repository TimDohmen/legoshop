using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legokit.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lego.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BricksController : ControllerBase
  {
    private readonly BricksService _bs;

    public BricksController(BrickService bs)
    {
      _bs = bs;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Brick>> Get()
    {
      try
      {
        return Ok(_bs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Brick> Get(int id)
    {
      try
      {
        return Ok(_bs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Brick> Post([FromBody] string value)
    {
      try
      {
        return Ok(_bs.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
}
