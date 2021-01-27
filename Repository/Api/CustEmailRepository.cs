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
    public class CustEmailRepository : RepositoryBase<CustEmail>,ICustEmailRepository 
    {
        private DbContext context;
        public CustEmailRepository(DbContext dbContext) : base(dbContext)
        {
            context=dbContext;
        }

     
    }
}