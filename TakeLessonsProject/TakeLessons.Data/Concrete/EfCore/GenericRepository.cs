using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeLessons.Data.Abstract;

namespace TakeLessons.Data.Concrete.EfCore
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
            //Bu kısımda branş bağlantısı olmadan öğretmenleri listeledim.
            //var result = await _dbContext
            //    .Set<TEntity>()
            //    .ToListAsync();
            //return result;
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
