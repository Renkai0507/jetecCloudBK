using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BkServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BkServer.Repository.Interface;

namespace BkServer.Repository
{
    public class AccountRepository : RepositoryBase<Account>,IAccountRepository
    {
        private DbContext context;
        public AccountRepository(DbContext dbContext) : base(dbContext)
        {
            context=dbContext;
        }

     
    }
}