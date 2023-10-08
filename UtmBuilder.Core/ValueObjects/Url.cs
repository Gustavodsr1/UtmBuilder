using System.Text;
using UtmBuilder.Core.ValueObjects.Execptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {
         public Url(string address) 
        {
            Address = address;  
            InvalidUrlExeption.ThrowIfInvalid(address);
        }

        public string Address { get; }  

    }
}
