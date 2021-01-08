using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

    [JsonIgnore]
    public virtual ICollection<Persona> Personas { get; set; }

  }
}
