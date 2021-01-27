using System.Threading.Tasks;
using BkServer.Dtos;
using BkServer.Models;

namespace BkServer.Service.Interface
{
    public interface IAlarmLog
    {
         Task<PagedResultDto<AlarmLog>> GetPaginatedResult(GetLogInput input);
    }
}