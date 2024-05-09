using HaulEaseNetcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaulEaseNetcore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TrackingController : ControllerBase
  {
    private readonly HaulEaseDBContext _context;
    public TrackingController(HaulEaseDBContext context)
    {
      _context = context;
    }

    // GET: api/tracking
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tracking>>> GetTrackings()
    {
      var _trackingList = await _context.Trackings.ToListAsync();

      return Ok(_trackingList);
    }

    // GET: api/tracking/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Tracking>> GetTracking(int id)
    {
      var _tracking = await _context.Trackings.FindAsync(id);

      if (_tracking == null)
      {
        return NotFound();
      }

      return Ok(_tracking);
    }

    // POST: api/tracking
    [HttpPost]
    public async Task<ActionResult<Tracking>> PostTracking(Tracking _tracking)
    {
      _context.Trackings.Add(_tracking);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTracking", new { id = _tracking.TrackingId }, _tracking);
    }

    // PUT: api/tracking/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTracking(int id, Tracking _tracking)
    {
      if (id != _tracking.TrackingId)
      {
        return BadRequest();
      }

      _context.Entry(_tracking).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TrackingExists(id))
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

    // DELETE: api/tracking/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTracking(int id)
    {
      var _tracking = await _context.Trackings.FindAsync(id);

      if (_tracking == null)
      {
        return NotFound();
      }

      _context.Trackings.Remove(_tracking);
      await _context.SaveChangesAsync();

      return Ok();
    }

    private bool TrackingExists(int id)
    {
      return _context.Trackings.Any(e => e.TrackingId == id);
    }
  }
}
