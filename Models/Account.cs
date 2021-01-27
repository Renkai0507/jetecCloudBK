using System;
using System.Collections.Generic;

namespace BkServer.Models
{
    public partial class Account
    {
        public string Cid { get; set; }
        public string Subid { get; set; }
        public string Subpwd { get; set; }
        public int Supervisor { get; set; }
    }
}
