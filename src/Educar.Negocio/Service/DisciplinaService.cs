using Educar.Negocio.Interface;
using Educar.Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Educar.Negocio.Service
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _DisciplinaRepository;

        public DisciplinaService(IDisciplinaRepository disciplinaRepository)
        {
            _DisciplinaRepository = disciplinaRepository;
        }
        
        public async Task Adicionar(Disciplina disciplina)
        {
           await _DisciplinaRepository.Adicionar(disciplina);
        }

        public async Task Atualizar(Disciplina disciplina)
        {
            await _DisciplinaRepository.Atualizar(disciplina);
        }

        public async Task<IEnumerable<Disciplina>> Filtrar(Expression<Func<Disciplina, bool>> expression)
        {
            return await _DisciplinaRepository.Filtrar(expression); 
        }

        public async Task<Disciplina> ObterPorId(int id)
        {
            return await _DisciplinaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Disciplina>> ObterTodos()
        {
            return await _DisciplinaRepository.ObterTodos();
        }

        public async Task Remover(Disciplina disciplina)
        {
            await _DisciplinaRepository.Remover(disciplina);
        }

        public void Dispose()
        {
            _DisciplinaRepository?.Dispose();
        }
    }
}
