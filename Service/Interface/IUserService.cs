using System.Collections.Generic;
using System.Threading.Tasks;
using BkServer.Dtos;
using BkServer.Models;

namespace BkServer.Service.Interface
{
    public interface IUserService
    {
        Task<PagedResultDto<User>> GetPaginatedResult(GetUserInput input);
    }
}