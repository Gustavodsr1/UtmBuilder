using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UtmBuilder.Core.ValueObjects.Execptions
{
    public partial class InvalidUrlExeption : Exception
    {
        private const string DefaltErrorMessage = "Invalid Url";

        
        public InvalidUrlExeption(string message = DefaltErrorMessage) : base(message) 
        {
          
        }

        public static void ThrowIfInvalid(string address, string message = DefaltErrorMessage)
        {
            if (string.IsNullOrEmpty(address))
                throw new InvalidUrlExeption(message);
            
            if (!UrlRegex().IsMatch(address))
                throw new InvalidUrlExeption();
        }

        [GeneratedRegex("^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$")]
        private static partial Regex UrlRegex();
    }
}
