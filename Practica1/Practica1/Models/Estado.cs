using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica1.Models
{
    public class Estado
    {  
            public int estadoID { get; set; }
            public string nombreEstado { get; set; }
        
        public virtual ICollection<Municipio> municipios { get; set; }       
    }
}