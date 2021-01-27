using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BkServer.Models;
using BkServer.Repository;
using Microsoft.AspNetCore.Authorization;
using BkServer.ViewModels;
using BkServer.Service.Interface;
using BkServer.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BkServer.Controllers
{
    [Authorize]
    public class CloudAccountController : Controller
    {
         private IRepositoryWrapper RepositoryWrapper{get;}  
         private ICloudAccountService CloudAccountService;
         private IAlarmLog Logservice;

        public CloudAccountController(IRepositoryWrapper repository,ICloudAccountService service,IAlarmLog logservice)
        {
            Logservice=logservice;
            RepositoryWrapper = repository;
            CloudAccountService=service;
        }

        public async Task<IActionResult> Master(GetCloudAccountInput input)
        {            
            var proxyid=int.Parse(User.FindFirst("ProxyId").Value) ;
            var dtos = await CloudAccountService.GetPaginatedResult(input,proxyid);
            var proxycoms = await RepositoryWrapper.ProxyCompany.GetAllListAsync();
         
            
            ViewBag.proxycoms=proxycoms;
           
            switch(input.Sorting)
            {
                case "Cid":                    
                    ViewBag.sortId="Cid_desc";
                    break;
                case "Cid_desc":                    
                    ViewBag.sortId="Cid";
                    break;
                case "group":                     
                    ViewBag.sortgroup="group_desc";
                    break;
                case "group_desc":                     
                    ViewBag.sortgroup="group";
                    break;
                case "type":                     
                    ViewBag.sorttype="type_desc";
                    break;
                case "type_desc":                     
                    ViewBag.sorttype="type";
                    break;
                case "enddate":                     
                    ViewBag.sortenddate="enddate_desc";
                    break;
                case "enddate_desc":
                    
                    ViewBag.sortenddate="enddate";
                    break;
                case "proxy":
                    
                    ViewBag.sortproxy="proxy_desc";
                    break;
                case "proxy_desc":
                    
                    ViewBag.sortproxy="proxy";
                    break;
                default:
                    ViewBag.sortId="Cid";
                    ViewBag.sortgroup="group";
                    ViewBag.sorttype="type";
                    ViewBag.sortenddate="enddate";
                    ViewBag.sortproxy="proxy";
                    break;
            }
                
            
            return View(dtos);
        }

        
        
        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {            
            var cust =await RepositoryWrapper.CustMast.FirstorDefaultAsync(X=>X.Cid==Id);
            if (cust==null)
            {
                ViewBag.ErroMessage=Id;
                return View("NotFound");
            }
            var proxy = await RepositoryWrapper.ProxyCompany.GetAllListAsync();
            var Custsensors= await RepositoryWrapper.RemotedataRecent.GetAllListAsync(X=>X.Cid==Id);
            var custline =await RepositoryWrapper.LinekeyRepository.FirstorDefaultAsync(X=>X.Cid==Id);
            var devicese = await RepositoryWrapper.DeviceShow.GetAllListAsync(X=>X.Cid==Id);
            var accountcnt = await RepositoryWrapper.Account.CountAsync(X=>X.Cid==Id);
            var emailcnt =await RepositoryWrapper.CustEmail.CountAsync(X=>X.Cid==Id);
            var LinesetTime = await RepositoryWrapper.LinekeyRepository.FirstorDefaultAsync(X=>X.Cid==Id);
            
            CustDetailVM model=new CustDetailVM();
            model.sensors=Custsensors;
            model.Devicese=devicese;
            model.custline=custline;
            model.cust=cust;
            model.AccountCnt=accountcnt;
            model.EmailCnt=emailcnt;
            model.Lineset=LinesetTime==null?"尚未設置Line警報": LinesetTime.Setdate+"更新警報設定";

            var proxycom = await RepositoryWrapper.ProxyCompany.GetAllListAsync();
            model.proxycom=new List<SelectListItem>();
            model.proxycom.Add(new SelectListItem{Value="0",Text="請選擇"});
            foreach(var com in proxycom)
            {
                model.proxycom.Add(new SelectListItem
                {
                    Value=com.Id.ToString(),
                    Text=com.CompanyName
                    
                });
            }
            
            ViewBag.proxycoms=proxy;
            return View(model);
        }
        public  IActionResult CreateCloud()
        {           
            return View();
        }
         public async Task<IActionResult> Create(CreateCloudVM vM)
        {           
            if(!ModelState.IsValid)
            {
                return View("CreateCloud");
            }

            //重複新增檢查
            var repeatcheck = await RepositoryWrapper.CustMast.FirstorDefaultAsync(X=>X.Cid==vM.Cid);                
                if(repeatcheck!=null)
                {
                    ViewBag.repeat="repeat";
                    return View("CreateCloud");
                }
            //重複新增檢查

            DateTime today=vM.RegistDatetime;
            //期限判斷
            DateTime enddate=vM.Enddate;
            // enddate=enddate.AddDays(7);
            //期限判斷

            //功能判斷
            string Function=vM.CustFuncion.Equals("基本型")?"BR":"BCLER";
            //功能判斷

            // 創建企業帳號
            await RepositoryWrapper.CustMast.InsertAsync(new CustMast
            {
                Cid=vM.Cid,
                Pwd="000000",
                Email=vM.Email,
                Group=vM.Group,
                Renew="",
                Registdate=today.ToString("yyyy/MM/dd"),
                Registtime=today.ToString("HH:mm:ss"),
                Enddate=enddate.ToString("yyyy/MM/dd"),
                Vip=false,
                Allowstatus="allow",
                Savedays=90,
                Function=Function

            });
            //預設登入帳號
            await RepositoryWrapper.Account.InsertAsync(new Account
            {
                Cid=vM.Cid,
                Subid=vM.Cid,
                Subpwd="000000",
                Supervisor=2
            });
            // 預設信箱
            await RepositoryWrapper.CustEmail.InsertAsync(new CustEmail
            {
                Cid=vM.Cid,
                Email=vM.Email,
                Undelete=1,
                Receive=1
            });
            if(vM.account!=null&&!vM.account.Equals(vM.Cid))
            {
                await RepositoryWrapper.Account.InsertAsync(new Account
                {
                     Cid=vM.Cid,
                     Subid=vM.account,
                     Subpwd="000000",
                     Supervisor=1
                });
            }

            return RedirectToAction("Details",new {Id=vM.Cid});
        }
        public async Task<IActionResult> Renew (FunctionEnum gonneng,string Id,CustDetailVM vm,string Enddate)
        {
            var Cust = await RepositoryWrapper.CustMast.FirstorDefaultAsync(X=>X.Cid==Id);
            //期限判斷
            DateTime startdate=DateTime.Now;
            
            
            //期限判斷
            
            //功能判斷
            string Function=gonneng.ToString().Equals("基本型")?"BR":"BCLER";
            //功能判斷            
            Cust.Renew=startdate.ToString("yyyy/MM/dd");
            Cust.Enddate=vm.Enddate.ToString("yyyy/MM/dd");
            await RepositoryWrapper.CustMast.UpdateAsync(Cust);
            
            return RedirectToAction("Details",new{Id=Id});
        }
        public async Task<IActionResult> DeleteData(string cid,string sid)
        {
          await RepositoryWrapper.Remotedata.DeleteAsync(X=>X.Cid==cid&&X.Sid==sid);
          await RepositoryWrapper.RemotedataRecent.DeleteAsync(X=>X.Cid==cid&&X.Sid==sid);
            return RedirectToAction("Details",new{Id=cid});
        }
        public async Task<IActionResult> Record(GetLogInput input)
        {            
            var dtos=await Logservice.GetPaginatedResult(input);
            var recordVM = new recordVM();
            recordVM.DataLogs=dtos;
            recordVM.cid=input.Id;
            return View(recordVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
