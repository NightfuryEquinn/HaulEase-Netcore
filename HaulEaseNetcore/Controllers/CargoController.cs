using HaulEaseNetcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaulEaseNetcore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CargoController : ControllerBase
  {
    private readonly HaulEaseDBContext _context;
    public CargoController(HaulEaseDBContext context)
    {
      _context = context;
    }

    // GET: api/cargo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cargo>>> GetCargos()
    {
      var _cargoList = await _context.Cargos.ToListAsync();

      return Ok(_cargoList);
    }

    // GET: api/cargo/shipment/1
    [HttpGet("shipment/{shipmentId}")]
    public async Task<ActionResult<IEnumerable<Cargo>>> GetCargosByShipment(int shipmentId)
    {
      var _cargoList = await _context.Cargos
        .Where(c => c.ShipmentId == shipmentId)
        .ToListAsync();

      if (_cargoList == null)
      {
        return NotFound();
      }

      return Ok(_cargoList);
    }

    // GET: api/cargo/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Cargo>> GetCargo(int id)
    {
      var _cargo = await _context.Cargos.FindAsync(id);

      if (_cargo == null)
      {
        return NotFound();
      }

      return Ok(_cargo);
    }

    // POST: api/cargo
    [HttpPost]
    public async Task<ActionResult<Cargo>> PostCargo(Cargo _cargo)
    {
      _context.Cargos.Add(_cargo);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCargo", new { id = _cargo.CargoId }, _cargo);
    }

    // PUT: api/cargo/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCargo(int id, Cargo _cargo)
    {
      if (id != _cargo.CargoId)
      {
        return BadRequest();
      }

      var existingCargo = await _context.Cargos.FindAsync(id);
      if (existingCargo == null)
      {
        return NotFound();
      }

      if (string.IsNullOrEmpty(_cargo.Image))
      {
        _cargo.Image = existingCargo.Image;
      }

      // Update modified data
      _context.Entry(existingCargo).CurrentValues.SetValues(_cargo);
      _context.Entry(existingCargo).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CargoExists(id))
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

    // DELETE: api/cargo/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCargo(int id)
    {
      var _cargo = await _context.Cargos.FindAsync(id);

      if (_cargo == null)
      {
        return NotFound();
      }

      _context.Cargos.Remove(_cargo);
      await _context.SaveChangesAsync();

      return Ok();
    }

    private bool CargoExists(int id)
    {
      return _context.Cargos.Any(e => e.CargoId == id);
    }
  }
}
