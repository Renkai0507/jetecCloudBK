using System.Collections.Generic;
using System.Threading.Tasks;
using BkServer.Dtos;
using BkServer.Models;

namespace BkServer.Service.Interface
{
    public interface ICloudAccountService
    {
        Task<PagedResultDto<CustMast>> GetPaginatedResult(GetCloudAccountInput input,int proxyid);
    }
}