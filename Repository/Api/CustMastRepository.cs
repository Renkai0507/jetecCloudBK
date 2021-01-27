using BkServer.Models;
using BkServer.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BkServer.Repository
{
    public class CustMastRepository :RepositoryBase<CustMast> , ICustMastRepository
    {
         private DbContext context;
        public CustMastRepository(DbContext dbContext) : base(dbContext)
        {
            context=dbContext;
        }
    }
}