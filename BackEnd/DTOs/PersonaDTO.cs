using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTOs
{
  public class PersonaDTO
  {
    public int Id { get; set; }
    public string Identificacion { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public int SexoNombre{ get; set; }
    public int TipoIdentificacionNombre { get; set; }
  }
}
