﻿using Educar.Dados.Context;
using Educar.Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using Educar.Negocio.Interface;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Educar.Dados.Repository
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        private readonly CPSIContext _CPSIContext;
        public TurmaRepository(CPSIContext context) : base(context)
        {
            _CPSIContext = context;
        }

        public async Task<Turma> ObterTurma(int id)
        {
            return _Context.Turmas.Include(T => T.Disciplina).FirstOrDefault(T => T.Id == id);

        }

        public Task<List<Turma>> ObterTurmasComDisciplinas()
        {
            return _Context.Turmas.Include(T => T.Disciplina).ToListAsync();
        }
    }
}
