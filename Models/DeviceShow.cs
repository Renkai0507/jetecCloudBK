using System;
using System.Collections.Generic;

namespace BkServer.Models
{
    public partial class DeviceShow
    {
        public int Id { get; set; }
        public string Cid { get; set; }
        public string Sid { get; set; }
        public string Mname { get; set; }
        public string Chl { get; set; }
        public string Display { get; set; }
        public string Sw { get; set; }
        public string Showtime { get; set; }
        public int Rowcnt { get; set; }
    }
}
