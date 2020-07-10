using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using XGame.Domain.Entities.Base;
using XGame.Domain.Interfaces.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntidade, TId> : IRepositoryBase<TEntidade, TId>
        where TEntidade : EntityBase
        where TId : struct
    {

        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public TEntidade Adicionar(TEntidade entidade)
        {
            return _context.Set<TEntidade>().Add(entidade);
        }

        public IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> entidades)
        {
            return _context.Set<TEntidade>().AddRange(entidades);
        }

        public TEntidade Editar(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;

            return entidade;
        }

        public bool Existe(Func<TEntidade, bool> where)
        {
            return _context.Set<TEntidade>().Any(where);
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
                query = query.Include(property);

            return query;
        }

        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntidade> ListarEOrdenarPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);
        }

        public TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any())
                return Listar(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());

            return _context.Set<TEntidade>().Find(id);
        }

        public void Remover(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        public TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntidade> ListarEOrdenadosPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntidade> ListarOrdenadosPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }
    }
}
