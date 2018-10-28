using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema_YSCC.Dominio
{
    [Table("Cartelera")]
    public class Cartelera
    {

        [MaxLength(50)]
            public string Nombre { get; set; }
            public DateTime FechaEstreno { get; set; }
            public string Genero { get; set; }
            public string Recomendacion { get; set; }
            public int Duracion { get; set; }
            public string Imagen { get; set; }
            public Funciones[] Funciones { get; set; }

        
    }
}
