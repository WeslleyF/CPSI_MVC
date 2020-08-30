using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CPSI.Negocio.Modelo;

namespace CPSI.Negocio.Interface
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : Entidade 
    {
        Task Adicionar(TEntidade entidade);
        Task Atualizar(TEntidade entidade);
        Task Remover(TEntidade entidade);
        Task<IEnumerable<TEntidade>> ObterTodos();
        Task<IEnumerable<TEntidade>> Filtrar(Expression<Func<TEntidade, bool>> expression);
        Task<TEntidade> ObterPorId(int id);
        Task<int> SaveChanges();

    }
}
