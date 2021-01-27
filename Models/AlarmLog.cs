using System;
using System.Collections.Generic;

namespace BkServer.Models
{
    public partial class AlarmLog
    {
        public long Id { get; set; }
        public string Cid { get; set; }
        public string Sid { get; set; }
        public string Sname { get; set; }
        public string Textlog { get; set; }
        public string Alarmtime { get; set; }
    }
}
