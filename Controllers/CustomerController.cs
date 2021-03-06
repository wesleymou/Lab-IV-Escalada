using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escalada.Models;
using Escalada.Service;
using Escalada.Models.ViewModels;

namespace Escalada.Controllers
{
  [Microsoft.AspNetCore.Authorization.Authorize]
  public class CustomerController : Controller
  {
    private readonly EscaladaContext _context;

    public CustomerController(EscaladaContext context)
    {
      _context = context;
    }

    // GET: Customer
    public async Task<IActionResult> Index(bool excluidos)
    {
      var customers = await _context.Customers
          .Where(e => excluidos || !e.Excluido).ToListAsync();

      var model = new CustomerListViewModel
      {
        Customers = customers,
        ShowDeleted = excluidos
      };

      return View(model);
    }

    // GET: Customer/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var customer = await _context.Customers
          .FirstOrDefaultAsync(m => m.Id == id);
      if (customer == null)
      {
        return NotFound();
      }

      return View(customer);
    }

    // GET: Customer/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Customer/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Cpf,Nome,NumFone1,NumFone2,Endereco,Email")] Customer customer)
    {
      if (ModelState.IsValid)
      {
        _context.Add(customer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(customer);
    }

    // GET: Customer/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var customer = await _context.Customers.FindAsync(id);
      if (customer == null)
      {
        return NotFound();
      }
      return View(customer);
    }

    // POST: Customer/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Cpf,Nome,NumFone1,NumFone2,Endereco,Email")] Customer customer)
    {
      if (id != customer.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(customer);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CustomerExists(customer.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(customer);
    }

    // GET: Customer/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var customer = await _context.Customers
          .FirstOrDefaultAsync(m => m.Id == id);
      if (customer == null)
      {
        return NotFound();
      }

      return View(customer);
    }

    // POST: Customer/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var customer = await _context.Customers.FindAsync(id);
      customer.Excluido = true;
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CustomerExists(int id)
    {
      return _context.Customers.Any(e => e.Id == id);
    }
  }
}
