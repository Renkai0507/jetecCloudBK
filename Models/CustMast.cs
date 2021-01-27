using System;
using System.Collections.Generic;

namespace BkServer.Models
{
    public partial class CustMast
    {
        public int Id { get; set; }
        public string Cid { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public string Registdate { get; set; }
        public string Registtime { get; set; }
        public bool Vip { get; set; }
        public string Allowstatus { get; set; }
        public string Enddate { get; set; }
        public string Function { get; set; }
        public int Savedays { get; set; }
        public int TokenQty { get; set; }
        public string Group { get; set; }
        public string Renew { get; set; }
        public int ProxyId { get; set; }
    }
}
