using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using BkServer.Models;

namespace BkServer.Repository
{
    public class reg_UserRepository : RepositoryBase<RegUser>,IRegUser
    {
        private DbContext context;
        public reg_UserRepository(DbContext dbContext) : base(dbContext)
        {
            context=dbContext;
        }

     
    }
}