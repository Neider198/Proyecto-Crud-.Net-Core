using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTOs
{
  public class PersonaDetalleDTO
  {
    public int Id { get; set; }
    public string Identificacion { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string SexoNombre { get; set; }
    public string TipoIdentificacionNombre { get; set; }
  }
}
