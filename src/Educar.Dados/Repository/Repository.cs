using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Educar.Dados.Context;
using Educar.Negocio.Interface;
using Educar.Negocio.Modelo;
using Microsoft.EntityFrameworkCore;

namespace Educar.Dados.Repository
{
    public abstract class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entidade
    {
        protected readonly CPSIContext _Context;
        protected readonly DbSet<TEntidade> DBSet;

        protected Repository(CPSIContext context)
        {
            _Context = context;
            DBSet = context.Set<TEntidade>();
        }

        public virtual async Task Adicionar(TEntidade entidade)
        {
            DBSet.Add(entidade);
            await SaveChanges();
        }

        public virtual async Task Remover(TEntidade entidade)
        {
            DBSet.Remove(entidade);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntidade entidade)
        {
            DBSet.Update(entidade);
            await SaveChanges();
        }

        public virtual async Task<List<TEntidade>> ObterTodos()
        {
            return await DBSet.ToListAsync();
        }
        public virtual async Task<TEntidade> ObterPorId(int id)    
        {
            return await DBSet.FindAsync(id);
        }
        public virtual async Task<List<TEntidade>> Filtrar(Expression<Func<TEntidade, bool>> expression)
        {
            return await DBSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _Context?.Dispose(); 
        }

    }
}
