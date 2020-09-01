using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CPSI.Negocio.Modelo
{
    public class Disciplina : Entidade
    {
        [DisplayName("Disciplina")] 
        public string Nome { get; set; }
        public Disciplina()
        {

        }
    }
}
