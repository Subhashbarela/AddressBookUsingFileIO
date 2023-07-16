using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUsingFileIO
{
    public class Contacts
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string country { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        public Contacts(string firstName, string lastName, string country, string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.country = country;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
    }
}
