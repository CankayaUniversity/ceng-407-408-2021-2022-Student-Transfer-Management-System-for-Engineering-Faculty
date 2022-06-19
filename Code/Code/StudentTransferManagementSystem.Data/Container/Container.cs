using StudentTransferManagementSystem.Data.Entities;
using StudentTransferManagementSystem.Data.Repository.Classes;
using StudentTransferManagementSystem.Data.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data.Container
{
    public class Container : IContainer
    {
        private readonly ManagementSystemContext context;

        private Hashtable repository;

        public Container(ManagementSystemContext context)
        {
            this.context = context;
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (this.repository == null)
            {
                this.repository = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!this.repository.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), this.context);

                this.repository.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)this.repository[type];
        }
    }
}
