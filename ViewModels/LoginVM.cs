using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BkServer.ViewModels
{
    public  class LoginVM 
    {
      
        [Display(Name = "帳號")]
        [StringLength(20)]
        [Required]
        public string user_id { get; set; }
         [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        [StringLength(12)]
        public string Pwd { get; set; }
      
        
        
    }
}
