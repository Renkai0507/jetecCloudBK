using System;
using System.Collections.Generic;

namespace BkServer.Models
{
    public partial class DeviceSet
    {
        public int Id { get; set; }
        public string Cid { get; set; }
        public string Sid { get; set; }
        public string Pv { get; set; }
        public string Ih { get; set; }
        public string Il { get; set; }
        public string Dp { get; set; }
        public string Eh { get; set; }
        public string El { get; set; }
        public string Cl { get; set; }
    }
}
