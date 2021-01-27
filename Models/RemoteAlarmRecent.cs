using System;
using System.Collections.Generic;

namespace BkServer.Models
{
    public partial class RemoteAlarmRecent
    {
        public int Id { get; set; }
        public string Cid { get; set; }
        public string Sid { get; set; }
        public string SName { get; set; }
        public string Type { get; set; }
        public string Typename { get; set; }
        public string Eh { get; set; }
        public string El { get; set; }
        public string Value { get; set; }
        public string Dp { get; set; }
        public string SendDate { get; set; }
        public string SendTime { get; set; }
        public string AlarmTime { get; set; }
        public string Device { get; set; }
        public string RelayStatus { get; set; }
        public string AutoSwitch { get; set; }
    }
}
