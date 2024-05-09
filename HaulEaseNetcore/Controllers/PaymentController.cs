using HaulEaseNetcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaulEaseNetcore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PaymentController : ControllerBase
  {
    private readonly HaulEaseDBContext _context;
    public PaymentController(HaulEaseDBContext context)
    {
      _context = context;
    }

    // GET: api/payment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
    {
      var _payments = await _context.Payments.ToListAsync();

      return Ok(_payments);
    }

    // GET: api/payment/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Payment>> GetPayment(int id)
    {
      var _payment = await _context.Payments.FindAsync(id);

      if (_payment == null)
      {
        return NotFound();
      }

      return Ok(_payment);
    }

    // POST: api/payment
    [HttpPost]
    public async Task<ActionResult<Payment>> PostPayment(Payment _payment)
    {
      _context.Payments.Add(_payment);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetPayment", new { id = _payment.PaymentId }, _payment);
    }

    // PUT: api/payment/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPayment(int id, Payment _payment)
    {
      if (id != _payment.PaymentId)
      {
        return BadRequest();
      }

      _context.Entry(_payment).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PaymentExists(id))
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

    // DELETE: api/payment/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePayment(int id)
    {
      var _payment = await _context.Payments.FindAsync(id);

      if (_payment == null)
      {
        return NotFound();
      }

      _context.Payments.Remove(_payment);
      await _context.SaveChangesAsync();

      return Ok();
    }

    private bool PaymentExists(int id)
    {
      return _context.Payments.Any(e => e.PaymentId == id);
    }
  }
}
