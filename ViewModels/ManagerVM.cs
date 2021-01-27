using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BkServer.Dtos;
using BkServer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BkServer.ViewModels
{
    public class ManagerVM
    {
        public int proxyId{set;get;}
        public List<SelectListItem> proxycom{set;get;}
        public UserTypeEnum userTypeenum{set;get;}        
        public PagedResultDto<User> users{set;get;}
        public IEnumerable<RegUser> regusers{set;get;}
    }
    // public enum UserTypeEnum
    // {
    //     [Display(Name="業務")]
    //     sales,
       
       
    //     [Display(Name="代理")]
    //     proxy,
    //      [Display(Name="管理者")]
    //     admin,
    //     [Display(Name="無權限")]
    //     guest
    // }
}