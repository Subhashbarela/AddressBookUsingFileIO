using Newtonsoft.Json;
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
               // Console.WriteLine("Contact added successfully!");
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
        public void ReadFromFile(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] contactFields = line.Split(',');
                        Contacts contact = new Contacts(contactFields[0], contactFields[1], contactFields[2], contactFields[3], contactFields[4]);
                        ContactInfo.Add(contact);
                    }
                }

                Console.WriteLine("Address book read from file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from file: {0}", ex.Message);
            }
        }
        public void ExportToCsv(string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("First Name,Last Name,Country,Phone Number,Email");
                    foreach (Contacts contact in ContactInfo)
                    {
                        sw.WriteLine("{0},{1},{2},{3},{4}", contact.firstName, contact.lastName, contact.country, contact.phoneNumber, contact.email);
                    }
                }

                Console.WriteLine("Address book exported to CSV file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting to CSV file: {0}", ex.Message);
            }
        }
        public void WriteToJsonFile(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(ContactInfo, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, json);

                Console.WriteLine("Address book written to file successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: {0}", ex.Message);
            }
        }
        public void ReadFromJsonFile(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                ContactInfo = JsonConvert.DeserializeObject<List<Contacts>>(json);
                foreach(Contacts contact in ContactInfo)
                {
                    Console.WriteLine("First Name : "+contact.firstName);
                    Console.WriteLine("Last Name : "+contact.lastName);
                    Console.WriteLine("Country  : "+contact.country);
                    Console.WriteLine("PhoneNumber : "+contact.phoneNumber);
                    Console.WriteLine("Email : "+contact.email);
                    Console.WriteLine("\n.................................\n");
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from file: {0}", ex.Message);
            }
        }
    }
}
