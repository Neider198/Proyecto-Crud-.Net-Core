using BackEnd.DTOs;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.context;

namespace BackEnd.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PersonaController : ControllerBase
  {
    public readonly AplicacionDbContext _context;
    public PersonaController(AplicacionDbContext contexto)
    {
      _context = contexto;
    }

    public static PersonaDTO PersonaToDTO(Persona persona) => new PersonaDTO
    {
      Id = persona.Id,
      Identificacion = persona.Identificacion,
      Nombres = persona.Nombres,
      Apellidos = persona.Apellidos,
      Direccion = persona.Direccion,
      Telefono = persona.Telefono,
      SexoNombre = persona.SexoId,
      TipoIdentificacionNombre = persona.TipoIdentififcacionId,
    };

    //GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonaDetalleDTO>>> GetPersonas()
    {
      var personas = await _context.Personas.Select(x =>
      new PersonaDetalleDTO()
      {
        Id = x.Id,
        Identificacion = x.Identificacion,
        Nombres = x.Nombres,
        Apellidos = x.Apellidos,
        Direccion = x.Direccion,
        Telefono = x.Telefono,
        SexoNombre = x.Sexo.Nombre,
        TipoIdentificacionNombre = x.TipoIdentificacion.Nombre,
      }).ToListAsync();

      return personas;
    }

    //GET/ID
    [HttpGet("{id}")]
    public async Task<ActionResult<PersonaDetalleDTO>> GetPersona(int id)
    {
      var personaItem = await _context.Personas.Select(x =>
      new PersonaDetalleDTO()
      {
        Id = x.Id,
        Identificacion = x.Identificacion,
        Nombres = x.Nombres,
        Apellidos = x.Apellidos,
        Direccion = x.Direccion,
        Telefono = x.Telefono,
        SexoNombre = x.Sexo.Nombre,
        TipoIdentificacionNombre = x.TipoIdentificacion.Nombre,
      }).SingleOrDefaultAsync(b => b.Id == id);

      if (personaItem == null)
      {
        return NotFound("El Registro con el Id " + id + " No existe");
      }
      return personaItem;
    }

    //POST
    [HttpPost]
    public async Task<ActionResult<PersonaDTO>> PostPersona(PersonaDTO personaDTO)
    {
      var persona = new Persona
      {
        Identificacion = personaDTO.Identificacion,
        Nombres = personaDTO.Nombres,
        Apellidos = personaDTO.Apellidos,
        Direccion = personaDTO.Direccion,
        Telefono = personaDTO.Telefono,
        SexoId = personaDTO.SexoNombre,
        TipoIdentififcacionId = personaDTO.TipoIdentificacionNombre
      };

      _context.Personas.Add(persona);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetPersonas),
        new { id = persona.Id },
        PersonaToDTO(persona));
    }

    //PUT
    [HttpPut("{id}")]
    public async Task<ActionResult<PersonaDTO>> PutPersona(int id, PersonaDTO personaDTO)
    {
      if (id != personaDTO.Id)
      {
        return BadRequest();
      }

      var personaItem = await _context.Personas.FindAsync(id);
      if (personaItem == null)
      {
        return NotFound();
      }

      personaItem.Identificacion = personaDTO.Identificacion;
      personaItem.Nombres = personaDTO.Nombres;
      personaItem.Apellidos = personaDTO.Apellidos;
      personaItem.Direccion = personaDTO.Direccion;
      personaItem.Telefono = personaDTO.Telefono;
      personaItem.SexoId = personaDTO.SexoNombre;
      personaItem.TipoIdentififcacionId = personaDTO.TipoIdentificacionNombre;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        return NotFound();
      }
      return NoContent();
    }

    //DELETE
    [HttpDelete("{id}")]
    public async Task<ActionResult<PersonaDTO>> DeletePersona(int id)
    {
      var peronaItem = await _context.Personas.FindAsync(id);
      if (peronaItem == null)
      {
        return NotFound();
      }

      _context.Personas.Remove(peronaItem);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}

