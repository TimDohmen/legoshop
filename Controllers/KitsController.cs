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
  public class KitsController : ControllerBase
  {
    private readonly KitsService _ks;

    public KitsController(KitsService ks)
    {
      _ks = ks;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Kit>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Kit> Get(int id)
    {
      try
      {
        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Kit> Post([FromBody] Kit newKit)
    {
      try
      {
        return Ok(_ks.Create(newKit));
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
        return Ok(_ks.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

