using BackEnd.context;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SexoController : ControllerBase
  {
    public readonly AplicacionDbContext _context;
    public SexoController(AplicacionDbContext contexto)
    {
      _context = contexto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sexo>>> GetSexo()
    {
      return await _context.Sexos.ToListAsync();
    }
  }
}
