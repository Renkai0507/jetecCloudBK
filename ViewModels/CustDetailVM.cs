using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BkServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BkServer.ViewModels
{
    public class CustDetailVM
    {
        public CustMast cust{set;get;}
        public int AccountCnt{set;get;}
        public int EmailCnt{set;get;}

        public string Lineset{set;get;}
        public IEnumerable<DeviceShow> Devicese{set;get;}
        
        public IEnumerable<RemoteAlarmRecent> sensors{set;get;}
        public CustLinekey custline{set;get;}

        [Required(ErrorMessage="起始日期不能為空")]
        [Display(Name="到期日期")]
        // [BindProperty(SupportsGet = true)]
        public DateTime Enddate =DateTime.Now; 

        [Display(Name="功能特色")]
        public FunctionEnum CustFuncion{set;get;}

        public List<SelectListItem> proxycom{set;get;}

    }
 
}