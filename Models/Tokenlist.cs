using System;
using System.Collections.Generic;

namespace BkServer.Models
{
    public partial class Tokenlist
    {
        public int Id { get; set; }
        public string Cid { get; set; }
        public string Token { get; set; }
        public string LoginTime { get; set; }
    }
}
