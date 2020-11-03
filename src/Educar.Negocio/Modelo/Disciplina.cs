using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Educar.Negocio.Modelo
{
    public class Disciplina : Entidade
    {
        [DisplayName("Disciplina")] 

        //Relacionamentos
        public List<Turma> turmas {get; set;}

        public Disciplina()
        {

        }
    }
}
