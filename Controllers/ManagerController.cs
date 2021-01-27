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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Dynamic;
using BkServer.Service;
using BkServer.Service.Interface;
using BkServer.Dtos;

namespace BkServer.Controllers
{
    [Authorize(Roles="管理者")]
    public class ManagerController : Controller
    {
        
        private IBKRepository BKRepository{get;}  
        private IRepositoryWrapper RepositoryWrapper{get;} 
        private IUserService Userservice{get;}

        public ManagerController(IBKRepository bkRepository,IRepositoryWrapper repositoryWrapper,IUserService userService)
        {
            BKRepository = bkRepository;
            RepositoryWrapper=repositoryWrapper;
            Userservice=userService;
        }

        public async Task<IActionResult> Index(GetUserInput input)
        {
            ManagerVM model=new ManagerVM();            
            var regusers= await BKRepository.RegUser.GetAllListAsync();
            model.regusers=regusers;

           var dtos = Userservice.GetPaginatedResult(input);
            
            //排序處理
            switch(input.Sorting)
            {
                case "UserId":                    
                    ViewBag.sortId="UserId_desc";
                    break;
                case "UserId_desc":                    
                    ViewBag.sordId="UserId";
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
                default:
                    ViewBag.sordId="UserId";
                    ViewBag.sortgroup="group";
                    ViewBag.sorttype="type";
                    break;
            }
            //排序處理

            model.users =await dtos;
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

            return View(model);
        }
    

     
         public async Task<IActionResult> open(ManagerVM vm,string id)
        {
            string today =DateTime.Now.ToString("yyyy/MM/dd,hh:mm:ss");
            var reguser= await BKRepository.RegUser.FirstorDefaultAsync(X=>X.UserId==id);
            await BKRepository.User.InsertAsync(new Models.User
            {
                UserId=reguser.UserId,
                UserName=reguser.UserName,
                UserType=vm.userTypeenum,
                Usergroup=reguser.Usergroup,
                UserPwd=reguser.UserPwd,
                Email=reguser.Email,
                ProxyId=vm.proxyId,
                Token="",
                Allowdate=today
            });
            await BKRepository.RegUser.DeleteAsync(reguser);
            return  RedirectToAction("Index");
        }
        public async Task<IActionResult> edit(ManagerVM vm,string id,string types)
        {
            var user= await BKRepository.User.FirstorDefaultAsync(X=>X.UserId==id);
               user.UserType=(UserTypeEnum)int.Parse(types);
               user.ProxyId=int.Parse(types)==1?vm.proxyId:0;
               
                   
               
               
            await BKRepository.User.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
          await BKRepository.User.DeleteAsync(X=>X.UserId==id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteReguser(string id)
        {
           await BKRepository.RegUser.DeleteAsync(X=>X.UserId==id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
