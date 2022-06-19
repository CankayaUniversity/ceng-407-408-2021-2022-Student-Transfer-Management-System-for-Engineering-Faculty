using StudentTransferManagementSystem.Data.Entities;
using StudentTransferManagementSystem.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Container
{
    public interface IContainer
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }
}
