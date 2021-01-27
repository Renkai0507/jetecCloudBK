using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BkServer.Models;
using BkServer.Repository;
using BkServer.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BkServer.Controllers
{
    [Authorize(Roles="管理者,業務")]
    public class ProxyController : Controller
    {
        
        private IRepositoryWrapper RepositoryWrapper{get;}  
        private IBKRepository RepositoryBK{get;}

        public ProxyController(IRepositoryWrapper repositoryWrapper,IBKRepository repositorybk)
        {
            RepositoryWrapper = repositoryWrapper;
            RepositoryBK =repositorybk;
        }

        public async Task<IActionResult> ProxyMaster()
        {
            ProxyMasterVM model=new ProxyMasterVM();
            var proxcm= await RepositoryWrapper.ProxyCompany.GetAllListAsync();
            model.proxycompanies=proxcm;
                        
            return View(model);
        }

     [Authorize(Roles="管理者")]
     [HttpGet]
         public IActionResult CreateProxy(string id)
        {
          return View();
        }
        [Authorize(Roles="管理者")]        
        [HttpPost]
        public async Task<IActionResult> CreateProxy(CreateProxyVM company)
        {
            await RepositoryWrapper.ProxyCompany.InsertAsync(new ProxyCompany
            {
                CompanyName=company.Name
            });
          return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
