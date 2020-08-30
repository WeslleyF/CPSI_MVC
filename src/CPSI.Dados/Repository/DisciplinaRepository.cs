using CPSI.Dados.Context;
using CPSI.Negocio.Interface;
using CPSI.Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CPSI.Dados.Repository
{
    public class DisciplinaRepository : Repository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(CPSIContext context) : base(context)
        {

        }
    }
}
