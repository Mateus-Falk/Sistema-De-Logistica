using Microsoft.EntityFrameworkCore;
using SistemaLogistica.Domain.IRepositories;
using SistemaLogistica.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogistica.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SQLServerContext _context;
        public BaseRepository(SQLServerContext context)
        {
            _context = context;
        }

        public Task<int> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> FindById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<int> Save(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task<int> Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                return _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return _context.SaveChangesAsync();
            }
        }
        public async Task<int> ExecuteCommand(string sqlCommand)
        {
            return await _context.Database.ExecuteSqlRawAsync(sqlCommand);
        }
    }
}
