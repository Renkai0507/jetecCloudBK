using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BkServer.Models;

namespace BkServer.ViewModels
{
    public class ProxyMasterVM
    {
        // public IEnumerable<int> custcount{set;get;}
        public IEnumerable<ProxyCompany> proxycompanies{set;get;}        
    }
 
}