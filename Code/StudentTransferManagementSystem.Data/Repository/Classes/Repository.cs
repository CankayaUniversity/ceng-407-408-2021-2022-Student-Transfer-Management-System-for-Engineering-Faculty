using Microsoft.EntityFrameworkCore;
using StudentTransferManagementSystem.Data.Entities;
using StudentTransferManagementSystem.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem.Data.Repository.Classes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private ManagementSystemContext context;

        public Repository(ManagementSystemContext context)
        {
            this.context = context;
        }

        public async Task Add(T entity)
        {
            this.context.Set<T>().Add(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByWithExpression(Expression<Func<T, bool>> where)
        {
            return await this.context.Set<T>().Where(where).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetByWithExpressionList(Expression<Func<T, bool>> where)
        {
            return await this.context.Set<T>().Where(where).ToListAsync();
        }

        public async Task<List<T>> ListAll()
        {
            return await this.context.Set<T>().ToListAsync();
        }
    }
}
