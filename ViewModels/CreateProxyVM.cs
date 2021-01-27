using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BkServer.Models;

namespace BkServer.ViewModels
{
    public class CreateProxyVM
    {
        [Required(ErrorMessage="請輸入代理公司名")]
        [Display(Name = "代理公司名")]        
        [StringLength(20)]
        public string Name{set;get;}        
    }
 
}