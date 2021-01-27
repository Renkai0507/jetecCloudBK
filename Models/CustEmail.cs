using System;
using System.Collections.Generic;

namespace BkServer.Models
{
    public partial class CustEmail
    {
        public int Id { get; set; }
        public string Cid { get; set; }
        public string Email { get; set; }
        public int Undelete { get; set; }
        public int Receive { get; set; }
    }
}
