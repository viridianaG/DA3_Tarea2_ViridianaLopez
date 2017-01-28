using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica1.Models
{
    public class Municipio
    {
            public int municipioID { get; set; }
            public string nombre { get; set; }

        public int estadoID { get; set; }

        virtual public Estado estado { get; set; }
    }
}