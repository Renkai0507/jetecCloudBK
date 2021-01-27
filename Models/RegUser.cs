using System;
using System.Collections.Generic;

namespace BkServer.Models
{
    public partial class RegUser
    {
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserTypeEnum UserType { get; set; }
        public string Usergroup { get; set; }
        public string RegistKey { get; set; }
        public bool EmailCertify { get; set; }
        public string RegistTime { get; set; }
    }
}
