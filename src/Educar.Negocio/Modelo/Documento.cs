using System;
using System.Collections.Generic;
using System.Text;

namespace Educar.Negocio.Modelo
{
    public class Documento : Entidade
    {
        public int Tipo {get; set;}
        public int ValidadeDias { get; set; }
        public bool TemValidade { get; set; }
    }
}
