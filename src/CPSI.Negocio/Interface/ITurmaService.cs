using CPSI.Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CPSI.Negocio.Interface
{
    public interface ITurmaService : IDisposable
    {
        Task Adicionar(Turma turma);
        Task Atualizar(Turma turma);
        Task Remover(Turma turma);
        Task<IEnumerable<Turma>> ObterTodos();
        Task<IEnumerable<Turma>> Filtrar(Expression<Func<Turma, bool>> expression);
        Task<Turma> ObterPorId(int id);
        Task<Turma> ObterTurma(int id);
        Task<List<Turma>> ObterTurmasComDisciplinas();
    }
}
