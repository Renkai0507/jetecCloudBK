using System.Linq;
using System.Threading.Tasks;
using BkServer.Dtos;
using BkServer.Models;
using BkServer.Repository;
using BkServer.Service.Interface;

namespace BkServer.Service
{
    public class AlarmlogService : IAlarmLog
    {
        private IRepositoryWrapper Repository;

        public AlarmlogService(IRepositoryWrapper repository)
        {
            Repository=repository;
        }
        public async Task<PagedResultDto<AlarmLog>> GetPaginatedResult(GetLogInput input)
        {
            var logs = await Repository.Alarmlog.GetAllListAsync(X=>X.Cid==input.Id);
            if (!string.IsNullOrEmpty(input.FilterText))
            {
                logs=logs.Where(X=>X.Sid.Contains(input.FilterText)||X.Sname.Contains(input.FilterText)||X.Textlog.Contains(input.FilterText)||X.Alarmtime.Contains(input.FilterText)).ToList();
            }
            var count =logs.Count();

            switch(input.FilterText)
            {
                case "sid":
                    logs=logs.OrderBy(S=>S.Sid).ToList();
                    break;
                case "sid_desc":
                    logs=logs.OrderByDescending(S=>S.Sid).ToList();
                    break;
                case "sname":
                    logs=logs.OrderBy(S=>S.Sname).ToList();
                    break;
                case "sname_desc":
                    logs=logs.OrderByDescending(S=>S.Sname).ToList();
                    break;
                case "text":
                    logs=logs.OrderBy(S=>S.Textlog).ToList();
                    break;
                case "text_desc":
                    logs=logs.OrderBy(S=>S.Textlog).ToList();
                    break;
                case "time":
                    logs=logs.OrderBy(S=>S.Alarmtime).ToList();
                    break;
                case "time_desc":
                    logs=logs.OrderByDescending(S=>S.Alarmtime).ToList();
                    break;
                default:
                     logs=logs.OrderByDescending(X=>X.Id).ToList();
                     break;
            }
            var dtos = new PagedResultDto<AlarmLog>
            {
                TotalCount=count,
                CurrentPage=input.CurrentPage,
                MaxResultCount=input.MaxResultCount,
                Data=logs,
                FilterText=input.FilterText,
                Sorting=input.Sorting
            };
            return dtos;
        }
    }
}