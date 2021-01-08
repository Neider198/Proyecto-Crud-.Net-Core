using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
  public class TipoIdentificacion
  {
    public TipoIdentificacion()
    {
      Personas = new HashSet<Persona>();
    }
    public int Id { get; set; }
    public int Nombre { get; set; }
    public virtual ICollection<Persona> Personas { get; set; }
  }
}
