using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationProject
{
    class Address
    {
        public String State;
        public String City;
        public int Zip;
        public String StreetAddress;

        public Address(String State, String City, int Zip, String StreetAddress)
        {
            this.State = State;
            this.City = City;
            this.Zip = Zip;
            this.StreetAddress = StreetAddress;
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("State:   ").Append(State).Append("\n");
            sb.Append("City:    ").Append(City).Append("\n");
            sb.Append("Zip:     ").Append(Zip).Append("\n");
            sb.Append("Street:  ").Append(StreetAddress).Append("\n");

            return sb.ToString();
        }
    }
}
