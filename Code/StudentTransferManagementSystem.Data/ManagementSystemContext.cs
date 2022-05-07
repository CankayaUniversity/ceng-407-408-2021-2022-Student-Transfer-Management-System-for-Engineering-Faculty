using Microsoft.EntityFrameworkCore;
using StudentTransferManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTransferManagementSystem.Data
{
    public class ManagementSystemContext : DbContext
    {

        public ManagementSystemContext(DbContextOptions<ManagementSystemContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users{ get; set; }
    }
}
