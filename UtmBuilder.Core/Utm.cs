using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core
{
    internal class Utm
    {
        public Utm (Url url, Campaign campaign) 
        {
            Url = url;  
            Campaign = campaign;
        }
        public Url Url { get; } 
        public Campaign Campaign { get; } 
    }
}
