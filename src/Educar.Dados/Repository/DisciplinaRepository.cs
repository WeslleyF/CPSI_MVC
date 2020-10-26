using Educar.Dados.Context;
using Educar.Negocio.Interface;
using Educar.Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educar.Dados.Repository
{
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(EducarContext context) : base(context)
        {

        }
    }
}
