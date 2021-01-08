using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
  public class Persona
  {
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public int SexoId { get; set; }
    public int TipoIdentififcacionId { get; set; }

    public virtual TipoIdentificacion TipoIdentificacion { get; set; }
    public virtual Sexo Sexo { get; set; }
  }
}
