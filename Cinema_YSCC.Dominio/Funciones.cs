using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_YSCC.Dominio
{
    [Table("Funciones")]
    public class Funciones
    {
        
        
            public string Cinema { get; set; }
            public string Sala { get; set; }
            public string Ciudad { get; set; }
            public int Precio { get; set; }
        
    }
}
