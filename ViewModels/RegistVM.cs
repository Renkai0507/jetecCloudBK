using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BkServer.ViewModels
{
    public  class RegistVM 
    {       
        [Display(Name = "帳號")]
        [StringLength(20)]
        [Required(ErrorMessage="請輸入帳號")]
         [Remote("User","VerifyRepeat")]
        public string UserId { get; set; }

        [Required(ErrorMessage="請輸入密碼")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        [StringLength(12)]
        public string Pwd { get; set; }
         [Required(ErrorMessage="請輸入確認密碼")]
        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Pwd",ErrorMessage="密碼與確認密碼不一致，請重新輸入")]
        [StringLength(12),]
        public string ConfirmPwd { get; set; }

        
        [Required(ErrorMessage="電子信箱不能為空")]
        [EmailAddress]
        [Display(Name="電子信箱")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage="確認信箱不能為空")]
        [EmailAddress]
        [Display(Name="確認信箱")]
        [Compare("Email",ErrorMessage="信箱不一致，請重新輸入")]
        [StringLength(50)]
        public string ConfirmEmail { get; set; }

         [Required(ErrorMessage="姓名不能為空,請輸入姓名")]
        [Display(Name="姓名")]
        [StringLength(10)]
        public string Name{set;get;}

         [Required(ErrorMessage="公司不能為空,請輸入")]
        [Display(Name="公司")]
        [StringLength(20)]
        public string usergroup{set;get;}
        
        
    }
    
}
