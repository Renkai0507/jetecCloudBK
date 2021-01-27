using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using BkServer.Models;
using BkServer.Repository.View.Interface;

namespace BkServer.Repository
{
    public class AlarmlogRepository : RepositoryBase<AlarmLog>,IAlarmlog
    {
        private DbContext context;
        public AlarmlogRepository(DbContext dbContext) : base(dbContext)
        {
            context=dbContext;
        }

     
    }
}