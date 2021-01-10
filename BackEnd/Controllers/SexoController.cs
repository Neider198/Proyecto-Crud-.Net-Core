using BackEnd.context;
using BackEnd.DTOs;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    private static SexoDTO SexoToDTO(Sexo sexo) => new SexoDTO
    {
      Id = sexo.Id,
      Nombre = sexo.Nombre,
    };

    private bool SexoItemExiste(long id) =>
     _context.Sexos.Any(e => e.Id == id);

    //GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SexoDTO>>> GetSexos()
    {
      return await _context.Sexos
        .Select(x => SexoToDTO(x))
        .ToListAsync();
    }

    //GET/id
    [HttpGet("{id}")]
    public async Task<ActionResult<SexoDTO>> GetSexo(int id)
    {
      var SexoItem = await _context.Sexos.FindAsync(id);

      if (SexoItem == null)
      {
        return NotFound();
      }

      return SexoToDTO(SexoItem);
    }

    //POST
    [HttpPost]
    public async Task<ActionResult<SexoDTO>> PostSexo(SexoDTO sexoDTO)
    {
      var sexo = new Sexo
      {
        Nombre = sexoDTO.Nombre
      };

      _context.Sexos.Add(sexo);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetSexos), new { id = sexo.Id}, SexoToDTO(sexo));
    }

    //PUT/id
    [HttpPut("{id}")]
    public async Task<ActionResult<SexoDTO>> PutSexo(int id, SexoDTO sexoDTO)
    { 
      if (id != sexoDTO.Id)
      {
        return BadRequest();
      }

      var SexoItem = await _context.Sexos.FindAsync(id);

      if (SexoItem == null)
      {
        return NotFound();
      }

      SexoItem.Nombre = sexoDTO.Nombre;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException) when (!SexoItemExiste(id))
      {
        return NotFound();
      }
      
      return NoContent();
    }

    //DELETE/id
    [HttpDelete("{id}")]
    public async Task<ActionResult<SexoDTO>> DeleteSexo(int id)
    {
      var SexoItem = await _context.Sexos.FindAsync(id);

      if (SexoItem == null)
      {
        return NotFound();
      }

      _context.Sexos.Remove(SexoItem);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
