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
    public class CustsidRepository : RepositoryBase<CustSid>,ICustSidRepository 
    {
        private DbContext context;
        public CustsidRepository(DbContext dbContext) : base(dbContext)
        {
            context=dbContext;
        }

     
    }
}