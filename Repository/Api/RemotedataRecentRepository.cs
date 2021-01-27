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
    public class RemotedataRecentRepository : RepositoryBase<RemoteAlarmRecent>,IRemotedataRecentRepository
    {
        private DbContext context;
        public RemotedataRecentRepository(DbContext dbContext) : base(dbContext)
        {
            context=dbContext;
        }

     
    }
}