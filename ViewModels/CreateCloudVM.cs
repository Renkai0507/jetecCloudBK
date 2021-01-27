using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BkServer.ViewModels
{
    public  class CreateCloudVM 
    {        
        [Display(Name = "企業ID")]
        [StringLength(20)]
        [Required(ErrorMessage="請輸入企業ID")]
        public string Cid { get; set; }
        [Display(Name = "預設登入帳號(非必須)")]
        [StringLength(20)]
        
        public string account { get; set; }


        [Remote(action: "VerifyRepeat", controller: "User",ErrorMessage = "Please enter a valid code")]
         [Required(ErrorMessage="電子信箱不能為空")]
        [EmailAddress]
        [Display(Name="預設電子信箱")]
        [StringLength(50)]
        public string Email { get; set; }

   
        
        [Required(ErrorMessage="公司不能為空,請輸入")]
        [Display(Name="公司")]
        [StringLength(20)]
        public string Group{set;get;}
        [Display(Name="功能特色")]
        public FunctionEnum CustFuncion{set;get;}
        [Required(ErrorMessage="起始日期不能為空")]
        [Display(Name="起始日期")]
        public DateTime RegistDatetime {set;get;}
        [Required(ErrorMessage="起始日期不能為空")]
        [Display(Name="到期日期")]
        public DateTime Enddate {set;get;}
    }

    public enum FunctionEnum
    {
        進階型,
        基本型,
    }
    
}
