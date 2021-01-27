using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BkServer.Models;

namespace BkServer.Repository.Interface
{
    public interface IRemotedataRepository :IRepositoryBase<RemoteAlarm>
    {
      Task<List<RemoteAlarm>>  UseSQL (string strsql);
    }
}