using CPSI.Negocio.Interface;
using CPSI.Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CPSI.Negocio.Service
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        public TurmaService(ITurmaRepository _turmaRepository)
        {
            this._turmaRepository = _turmaRepository;
        }

        public async Task Adicionar(Turma turma)
        {
           await _turmaRepository.Adicionar(turma);
        }

        public async Task Atualizar(Turma turma)
        {
            await _turmaRepository.Atualizar(turma);
        }

        public void Dispose()
        {
            _turmaRepository?.Dispose();
        }

        public async Task<IEnumerable<Turma>> Filtrar(Expression<Func<Turma, bool>> expression)
        {
            return await _turmaRepository.Filtrar(expression);
        }

        public async Task<Turma> ObterPorId(int id)
        {
            return await _turmaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Turma>> ObterTodos()
        {
            return await _turmaRepository.ObterTodos();
        }

        public Task<Turma> ObterTurma(int id)
        {
            return _turmaRepository.ObterTurma(id);

        }

        public Task<List<Turma>> ObterTurmasComDisciplinas()
        {
            return _turmaRepository.ObterTurmasComDisciplinas();
        }

        public async Task Remover(Turma turma)
        {
            await _turmaRepository.Remover(turma);
        }
    }
}
