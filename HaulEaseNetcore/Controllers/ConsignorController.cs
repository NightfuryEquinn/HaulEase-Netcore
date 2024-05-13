using HaulEaseNetcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaulEaseNetcore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ConsignorController : ControllerBase
  {
    private readonly HaulEaseDBContext _context;
    public ConsignorController(HaulEaseDBContext context)
    {
      _context = context;
    }

    // GET: api/consignor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Consignor>>> GetConsignors()
    {
      var _consignorList = await _context.Consignors.ToListAsync();

      return Ok(_consignorList);
    }

    // GET: api/consignor/email/johndoe@gmail.com/password/johndoe
    [HttpGet("email/{email}/password/{password}")]
    public async Task<ActionResult<Consignor>> CheckConsignor(string email, string password)
    {
      var _consignor = await _context.Consignors
        .FirstOrDefaultAsync(
          c => c.Email == email && c.Password == password
        );

      if (_consignor == null) 
      {
        return NotFound();
      }

      return Ok(_consignor);
    }

    // GET: api/consignor/email/johndoe@gmail.com
    [HttpGet("email/{email}")]
    public async Task<ActionResult<Consignor>> CheckConsignorEmail(string email)
    {
      var _consignor = await _context.Consignors
        .FirstOrDefaultAsync(
          c => c.Email == email
        );

      if (_consignor == null)
      {
        return NotFound();
      }

      return Ok(_consignor);
    }

    // GET: api/consignor/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Consignor>> GetConsignor(int id)
    {
      var _consignor = await _context.Consignors.FindAsync(id);

      if (_consignor == null)
      {
        return NotFound();
      }

      return Ok(_consignor);
    }

    // POST: api/consignor
    [HttpPost]
    public async Task<ActionResult<Consignor>> PostConsignor(Consignor _consignor)
    {
      _context.Consignors.Add(_consignor);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetConsignor", new { id = _consignor.ConsignorId }, _consignor);
    }

    // PUT: api/consignor/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutConsignor(int id, Consignor _consignor)
    {
      if (id != _consignor.ConsignorId)
      {
        return BadRequest();
      }

      _context.Entry(_consignor).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ConsignorExists(id))
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

    // DELETE: api/consignor/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConsignor(int id)
    {
      var _consignor = await _context.Consignors.FindAsync(id);

      if (_consignor == null)
      {
        return NotFound();
      }

      _context.Consignors.Remove(_consignor);
      await _context.SaveChangesAsync();

      return Ok();
    }

    private bool ConsignorExists(int id)
    {
      return _context.Consignors.Any(e => e.ConsignorId == id);
    }
  }
}
