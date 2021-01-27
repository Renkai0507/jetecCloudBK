using System;
using System.Collections.Generic;

namespace BkServer.Models
{
    public partial class RemoteAlarm
    {
        public long Id { get; set; }
        public string Cid { get; set; }
        public string Sid { get; set; }
        public string Type { get; set; }
        public string Eh { get; set; }
        public string El { get; set; }
        public string Value { get; set; }
        public string Dp { get; set; }
        public string SendDate { get; set; }
        public string SendTime { get; set; }
    }
}
