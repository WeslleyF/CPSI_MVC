using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Educar.Negocio.Modelo
{
    public class Turma : Entidade
    {   
       
        public int Ano { get; set; }
        [DisplayName("Horário")]
        public string Horario {get; set;}
        [DisplayName("Data Início")]
        public DateTime DataInicio { get; set; }
        [DisplayName("Data Fim")]
        public DateTime DataFim { get; set; }
        [DisplayName("Quantidade de Vagas")]
        public int QtdVagas { get; set; }

        //Relacionamento
        public Disciplina Disciplina {get; set;}
        public int DisciplinaId { get; set; }

        public Turma()
        {
                
        }
    }
}
