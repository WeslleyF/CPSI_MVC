using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Educar.Negocio.Modelo;

namespace Educar.Negocio.Interface
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : Entidade 
    {
        Task Adicionar(TEntidade entidade);
        Task Atualizar(TEntidade entidade);
        Task Remover(TEntidade entidade);
        Task<List<TEntidade>> ObterTodos();
        Task<List<TEntidade>> Filtrar(Expression<Func<TEntidade, bool>> expression);
        Task<TEntidade> ObterPorId(int id);
        Task<int> SaveChanges();

    }
}
