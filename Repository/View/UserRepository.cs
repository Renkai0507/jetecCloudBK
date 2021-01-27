using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using BkServer.Models;

namespace BkServer.Repository
{
    public class UserRepository : RepositoryBase<User>,IUser
    {
        private DbContext context;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            context=dbContext;
        }

     
    }
}