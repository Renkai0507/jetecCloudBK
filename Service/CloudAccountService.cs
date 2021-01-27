using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BkServer.Dtos;
using BkServer.Models;
using BkServer.Repository;
using Microsoft.EntityFrameworkCore;

namespace BkServer.Service.Interface
{
    public class CloudAccountService  :ICloudAccountService
    {
        private readonly IRepositoryWrapper Repository;

        public CloudAccountService(IRepositoryWrapper repository)
        {
            Repository=repository;
        }
        
        public async Task<PagedResultDto<CustMast>> GetPaginatedResult(GetCloudAccountInput input,int proxyid)
        {
            var query =await Repository.CustMast.GetAllListAsync();
           

            var getProxyId =Repository.ProxyCompany.FirstorDefaultAsync(s=>s.CompanyName.Contains(input.FilterText));
            if (!string.IsNullOrWhiteSpace(input.FilterText))
            {
                query =query.Where(s=>s.Cid.Contains(input.FilterText)||s.Group.Contains(input.FilterText)
                ||s.ProxyId==getProxyId.Id).ToList();
            }
            if (proxyid!=0)
            {
                query =query.Where(X=>X.ProxyId==proxyid).ToList();
            }
            switch(input.Sorting)
            {
                case "Cid":
                    query=query.OrderBy(S=>S.Cid).ToList();                    
                    break;
                case "Cid_desc":
                    query=query.OrderByDescending(S=>S.Cid).ToList();                    
                    break;
                case "group":
                     query=query.OrderBy(S=>S.Group).ToList();                   
                    break;
                case "group_desc":
                     query=query.OrderByDescending(S=>S.Group).ToList();                  
                    break;
                case "type":
                     query=query.OrderBy(S=>S.Allowstatus).ToList();
                   
                    break;
                case "type_desc":
                     query=query.OrderByDescending(S=>S.Allowstatus).ToList();
                   
                    break;
                case "enddate":
                     query=query.OrderBy(S=>S.Enddate).ToList();
                    
                    break;
                case "enddate_desc":
                    query=query.OrderByDescending(S=>S.Enddate).ToList();
                    
                    break;
                case "proxy":
                     query=query.OrderBy(S=>S.ProxyId).ToList();
                    
                    break;
                case "proxy_desc":
                    query=query.OrderByDescending(S=>S.ProxyId).ToList();
                    
                    break;    
                default:
                    query=query.OrderByDescending(S=>S.Id).ToList();                  
                    break;
            }


            var count = query.Count();
            query=  query.Skip((input.CurrentPage -1)*input.MaxResultCount).Take(input.MaxResultCount).ToList();            
            var dtos = new PagedResultDto<CustMast>
            {
                TotalCount=count,
                CurrentPage=input.CurrentPage,
                MaxResultCount=input.MaxResultCount,
                Data=query,
                FilterText=input.FilterText,
                Sorting =input.Sorting
            };
            return dtos;
        }


    }
}