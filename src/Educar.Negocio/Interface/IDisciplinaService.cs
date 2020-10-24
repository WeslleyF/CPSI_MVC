using Educar.Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Educar.Negocio.Interface
{
    public interface IDisciplinaService : IDisposable
    {
        Task Adicionar(Disciplina disciplina);
        Task Atualizar(Disciplina disciplina);
        Task Remover(Disciplina disciplina);
        Task<IEnumerable<Disciplina>> ObterTodos();
        Task<IEnumerable<Disciplina>> Filtrar(Expression<Func<Disciplina, bool>> expression);
        Task<Disciplina> ObterPorId(int id);
    }
}
