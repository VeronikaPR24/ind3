using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ind3_v1
{
    public class Address
    {
        private string organization;
        private string street;
        private string city;
        public Address(string o, string s, string c)
        {
            organization = o;
            street = s;
            city = c;
        }
        public void Update(string o, string s, string c)
        {
            organization = o;
            street = s;
            city = c;
        }
        public string Info()
        {
            return $"{organization}, {street}, {city}";
        }
    }
}
