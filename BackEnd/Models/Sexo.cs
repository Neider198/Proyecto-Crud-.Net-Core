using System.Collections.Generic;

namespace BackEnd.Models
{
  public class Sexo
  {
    public Sexo()
    {
      Personas = new HashSet<Persona>();
    }
    public int Id { get; set; }
    public string Nombre { get; set; }
    public virtual ICollection<Persona> Personas { get; set; }

  }
}
