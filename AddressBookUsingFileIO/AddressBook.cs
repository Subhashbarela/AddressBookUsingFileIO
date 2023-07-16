using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUsingFileIO
{
    public class AddressBook
    {
        public List<Contacts> ContactInfo { get; set; }

        public AddressBook()
        {
            ContactInfo = new List<Contacts>();
        }

        public void AddContact(Contacts contact)
        {
            bool isValid = ContactInfo.Exists(existingContact => existingContact.firstName == contact.firstName && existingContact.lastName == contact.lastName);

            if (!isValid)
            {
                ContactInfo.Add(contact);
                Console.WriteLine("Contact added successfully!");
            }
            else
            {
                Console.WriteLine("A contact with the same name already exists in the address book. Contact not added.");
            }
        }
        public void PrintContacts()
        {
            foreach (Contacts contact in ContactInfo)
            {
                Console.WriteLine("Name: {0} {1}\nCountry: {2}\nPhone: {3}\nEmail: {4}\n",
                    contact.firstName, contact.lastName, contact.country, contact.phoneNumber, contact.email);
            }
        }
        public void WriteToFile(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (Contacts contact in ContactInfo)
                    {
                        sw.WriteLine("{0},{1},{2},{3},{4}", contact.firstName, contact.lastName, contact.country, contact.phoneNumber, contact.email);
                    }
                }

                Console.WriteLine("Address book written to file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: {0}", ex.Message);
            }
        }
    }
}
