using HaulEaseNetcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaulEaseNetcore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShipmentController : ControllerBase
  {
    private readonly HaulEaseDBContext _context;
    public ShipmentController(HaulEaseDBContext context)
    {
      _context = context;
    }

    // GET: api/shipment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
    {
      var _shipmentList = await _context.Shipments.ToListAsync();

      return Ok(_shipmentList);
    }

    // GET: api/shipment/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Shipment>> GetShipment(int id)
    {
      var _shipment = await _context.Shipments.FindAsync(id);

      if (_shipment == null)
      {
        return NotFound();
      }

      return Ok(_shipment);
    }

    // POST: api/shipment
    [HttpPost]
    public async Task<ActionResult<Shipment>> PostShipment(Shipment _shipment)
    {
      _context.Shipments.Add(_shipment);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetShipment", new { id = _shipment.ShipmentId }, _shipment);
    }

    // PUT: api/shipment/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutShipment(int id, Shipment _shipment)
    {
      if (id != _shipment.ShipmentId)
      {
        return BadRequest();
      }

      _context.Entry(_shipment).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ShipmentExists(id))
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

    // DELETE: api/shipment/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShipment(int id)
    {
      var _shipment = await _context.Shipments.FindAsync(id);

      if (_shipment == null)
      {
        return NotFound();
      }

      _context.Shipments.Remove(_shipment);
      await _context.SaveChangesAsync();

      return Ok();
    }

    private bool ShipmentExists(int id)
    {
      return _context.Shipments.Any(e => e.ShipmentId == id);
    }
  }
}
