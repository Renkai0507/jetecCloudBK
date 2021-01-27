using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BkServer.Models;
using BkServer.Repository;
using BkServer.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using BkServer.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BkServer.Controllers
{
    
    public class UserController :Controller
    {
        private IBKRepository RepositoryWrapper{get;}  
        
      
        public UserController(IBKRepository repositoryWrapper)
        {
            RepositoryWrapper = repositoryWrapper;
        } 
        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> Create(RegistVM registvm)
        {                
            if (ModelState.IsValid)
            {                               
                var repeatcheck = await RepositoryWrapper.User.FirstorDefaultAsync(X=>X.UserId==registvm.UserId);    
                var repeatregist = await RepositoryWrapper.RegUser.FirstorDefaultAsync(X=>X.UserId==registvm.UserId);
                if(repeatcheck!=null||repeatregist!=null)
                {
                    ViewBag.repeat="repeat";
                    return View("Register");
                }

                var repeatemail = await RepositoryWrapper.User.FirstorDefaultAsync(X=>X.Email==registvm.Email);
                var repeatemailregist = await RepositoryWrapper.RegUser.FirstorDefaultAsync(X=>X.Email==registvm.Email);
                if (repeatemail!=null||repeatemail!=null)
                {
                    ViewBag.mailrepeat="repeat";
                    return View("Register");
                }

                var algorithm = MD5.Create();
                string merged = DateTime.Now.ToString() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
                    var mergedBytes = Encoding.UTF8.GetBytes(merged);
                    var hashedBytes = algorithm.ComputeHash(mergedBytes);
                    string hashedKey = BitConverter.ToString(hashedBytes).Replace("-","").ToUpper();

                var result= await RepositoryWrapper.RegUser.InsertAsync(new Models.RegUser()
                {
                    UserId=registvm.UserId,
                    UserName=registvm.Name,
                    UserPwd=registvm.Pwd,
                    Email=registvm.Email,
                    Usergroup=registvm.usergroup,
                    RegistKey=hashedKey,
                    EmailCertify=false                    
                });
                EmailSender mail =new EmailSender();
                string vertifyurl = Request.Host+"/User/MailVerify?c="+hashedKey;
                string Mailsubject="久德管理帳號認證";
                string mesg="<p>您好"+registvm.Name+"</p>"; 
                       mesg+="請點擊下方連結，認證您的信箱";
                       mesg+="<p>"+vertifyurl+"</p>";
                await mail.SendEmailAsync(registvm.Email,Mailsubject,mesg);
            }else
            {
                return View("Register");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if(!ModelState.IsValid)
            {               
                return View("../Home/index");
            }
            string returnUrl = Url.Content("~/");
            ClaimsIdentity claimsIdentity= new ClaimsIdentity();
            try
            {
                // 清除已經存在的登入 Cookie 內容
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }
            
            var user = await RepositoryWrapper.User.FirstorDefaultAsync(X=>X.UserId==login.user_id&&X.UserPwd==login.Pwd);
            if (user!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,user.UserType.ToString()),
                    new Claim("ProxyId",user.ProxyId.ToString())
                };
                   #region 建立 宣告式身分識別
                // ClaimsIdentity類別是宣告式身分識別的具體執行, 也就是宣告集合所描述的身分識別
                 claimsIdentity = new ClaimsIdentity(
                 claims, CookieAuthenticationDefaults.AuthenticationScheme);
                #endregion
            }else
            {               
                return LocalRedirect("/");
            }
            #region 建立關於認證階段需要儲存的狀態
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
            };
            #endregion

               try
            {
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return LocalRedirect(returnUrl);
        }
        [Authorize]
         public async Task<IActionResult> Logout()
         {
                try
            {
                // 清除已經存在的登入 Cookie 內容
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }
            return LocalRedirect("~/Home/index");
         }

         [AcceptVerbs("GET", "POST")]
         [AllowAnonymous]
        public async Task<IActionResult> VerifyRepeat(string UserId)
        {
         return Json(false);
        }
        
        public  IActionResult MailVerify( string c)
        {
            var verify= RepositoryWrapper.RegUser.FirstOrDefault(X=>X.RegistKey==c);            
            if (verify!=null)
            {
                verify.EmailCertify=true;
              RepositoryWrapper.RegUser.Update(verify);
                ViewBag.mesg=true;
                return View();
            }else
            {
                ViewBag.mesg=false;
                return View();
            }
        }
      

     
    }
}