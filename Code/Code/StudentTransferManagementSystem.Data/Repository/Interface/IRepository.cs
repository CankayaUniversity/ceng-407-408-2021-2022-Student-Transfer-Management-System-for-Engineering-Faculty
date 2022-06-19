using StudentTransferManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentTransferManagementSystem.Data.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        Task Delete(T entity);

        Task Save();

        Task<List<T>> ListAll();

        Task<T> GetById(int id);

        Task<T> GetByWithExpression(Expression<Func<T, bool>> where);

        Task<List<T>> GetByWithExpressionList(Expression<Func<T, bool>> where);
    }
}
