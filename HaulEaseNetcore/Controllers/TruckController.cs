using HaulEaseNetcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaulEaseNetcore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TruckController : ControllerBase
  {
    private readonly HaulEaseDBContext _context;
    public TruckController(HaulEaseDBContext context)
    {
      _context = context;
    }

    // GET: api/truck
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Truck>>> GetTrucks()
    {
      var _truckList = await _context.Trucks.ToListAsync();

      return Ok(_truckList);
    }

    // GET: api/truck/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Truck>> GetTruck(int id)
    {
      var _truck = await _context.Trucks.FindAsync(id);

      if (_truck == null)
      {
        return NotFound();
      }

      return Ok(_truck);
    }

    // POST: api/truck
    [HttpPost]
    public async Task<ActionResult<Truck>> PostTruck(Truck _truck)
    {
      _context.Trucks.Add(_truck);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTruck", new { id = _truck.TruckId }, _truck);
    }

    // PUT: api/truck/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTruck(int id, Truck _truck)
    {
      if (id != _truck.TruckId)
      {
        return BadRequest();
      }

      _context.Entry(_truck).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TruckExists(id))
        {
          return NotFound();
        }
        else
        {
          return BadRequest();
        }
      }

      return Ok();
    }

    // DELETE: api/truck/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTruck(int id)
    {
      var _truck = await _context.Trucks.FindAsync(id);

      if (_truck == null)
      {
        return NotFound();
      }

      _context.Trucks.Remove(_truck);
      await _context.SaveChangesAsync();

      return Ok();
    }

    private bool TruckExists(int id)
    {
      return _context.Trucks.Any(e => e.TruckId == id);
    }
  }
}
