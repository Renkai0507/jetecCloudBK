using System.Data;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BkServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.Common;
using BkServer.Repository.Interface;

namespace BkServer.Repository
{
    public class RemotedataRepository : RepositoryBase<RemoteAlarm>,IRemotedataRepository 
    {
        private DbContext context;
        public RemotedataRepository(DbContext dbContext) : base(dbContext)
        {
            context=dbContext;
            
        }
          public async Task<List<RemoteAlarm>> UseSQL(string sqlquery)
        {
            var con = context.Database.GetDbConnection();
            List<RemoteAlarm> datas= new List<RemoteAlarm>();
            try
            {
                await con.OpenAsync();
                using(var command = con.CreateCommand())
                {                    

                    command.CommandText=sqlquery;
                    DbDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {                        
                        while(await reader.ReadAsync())
                        {
                          var row= new RemoteAlarm
                          {
                              Cid=reader.GetString(1),
                              Sid=reader.GetString(2),
                              Type=reader.GetString(3),
                              Eh=reader.GetString(4),
                              El=reader.GetString(5),
                              Value=reader.GetString(6),
                              Dp=reader.GetString(7),
                              SendDate=reader.GetString(8),
                              SendTime=reader.GetString(9)
                          };
                          datas.Add(row);
                        }
                    
                    }
                     await reader.DisposeAsync();
                }              
            }
            catch (System.Exception)
            {
                
                throw;
            }
            finally
            {
             con.Close();   
            }
            return datas;
        }
       
    }
}