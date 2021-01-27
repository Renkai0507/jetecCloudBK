using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using BkServer.Models;

namespace BkServer.Repository
{
    public class ProxyCompanyRepository : RepositoryBase<ProxyCompany>,IProxyCompany
    {
        private DbContext context;
        public ProxyCompanyRepository(DbContext dbContext) : base(dbContext)
        {
            context=dbContext;
        }

     
    }
}