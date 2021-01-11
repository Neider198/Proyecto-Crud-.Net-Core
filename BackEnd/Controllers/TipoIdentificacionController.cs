using BackEnd.context;
using BackEnd.DTOs;
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
  public class TipoIdentificacionController : ControllerBase
  {
    public readonly AplicacionDbContext _context;

    public TipoIdentificacionController(AplicacionDbContext contexto)
    {
      _context = contexto;
    }

    public static TipoIdentificacionDTO TipoIdentificacionToDTO(
      TipoIdentificacion tipoIdentificacion) => new TipoIdentificacionDTO
      {
        Id = tipoIdentificacion.Id,
        Nombre = tipoIdentificacion.Nombre,
      };

    private bool TipoIdentificacionItemExiste(int id) =>
     _context.TipoIdentificacions.Any(e => e.Id == id);

    //GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipoIdentificacionDTO>>> GetTiposIdentificacion()
    {
      return await _context.TipoIdentificacions
        .Select( x => TipoIdentificacionToDTO(x))
        .ToListAsync();
    }

    //GET/id
    [HttpGet("{id}")]
    public async Task<ActionResult<TipoIdentificacionDTO>> GetTipoIdentificacion(int id)
    {
      var TipoIdentificacionItem = await _context.TipoIdentificacions.FindAsync(id);
      if (TipoIdentificacionItem == null)
      {
        return NotFound();
      }

      return TipoIdentificacionToDTO(TipoIdentificacionItem);
    }

    //POST
    [HttpPost]
    public async Task<ActionResult<TipoIdentificacionDTO>>  PostTipoIdentificacion(
      TipoIdentificacionDTO tipoIdentificacionDTO)
    {
      var tipoIdentificacion = new TipoIdentificacion
      {
        Nombre = tipoIdentificacionDTO.Nombre
      };

      _context.TipoIdentificacions.Add(tipoIdentificacion);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetTiposIdentificacion),
        new { id = tipoIdentificacion.Id },
        TipoIdentificacionToDTO(tipoIdentificacion));
    }

    //PUT
    [HttpPut("{id}")]
    public async Task<ActionResult<TipoIdentificacionDTO>> PutTipoIdentificacion(
      int id, TipoIdentificacionDTO tipoIdentificacionDTO)
    {
      if (id != tipoIdentificacionDTO.Id)
      {
        return BadRequest();
      }

      var TipoIdentificacionItem = await _context.TipoIdentificacions.FindAsync(id);
      if (TipoIdentificacionItem == null)
      {
        return NotFound();
      }

      TipoIdentificacionItem.Nombre = tipoIdentificacionDTO.Nombre;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException) when(!TipoIdentificacionItemExiste(id))
      {
        return NotFound();
      }

      return NoContent();
    }

    //DELETE
    [HttpDelete("{id}")]
    public async Task<ActionResult<TipoIdentificacionDTO>> DeleteTipoIdentificacion(int id)
    {
      var TipoIdentificacionItem = await _context.TipoIdentificacions.FindAsync(id);

      if (TipoIdentificacionItem == null)
      {
        return NotFound();
      }

      _context.TipoIdentificacions.Remove(TipoIdentificacionItem);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
