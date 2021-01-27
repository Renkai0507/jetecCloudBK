using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BkServer.Models
{
    public partial class User
    {
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public string UserName { get; set; }
        public UserTypeEnum UserType { get; set; }
        public string Token { get; set; }
        public string Usergroup { get; set; }
        public string Email { get; set; }
        public int? ProxyId { get; set; }
        public string Allowdate { get; set; }
    }
        public enum UserTypeEnum
    {
        [Display(Name="無權限")]
        無權限=0,
        [Display(Name="代理")]
        代理=1,
         [Display(Name="業務")]
        業務=2,
        [Display(Name="管理者")]
        管理者=3
    }
}
