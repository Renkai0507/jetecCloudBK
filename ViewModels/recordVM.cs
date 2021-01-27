using System.Collections.Generic;
using System.Linq;
using BkServer.Dtos;
using BkServer.Models;

namespace BkServer.ViewModels
{
    public class recordVM
    {
        public string cid;
        public PagedResultDto<AlarmLog> DataLogs;
    }
}