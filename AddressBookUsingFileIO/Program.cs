using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookUsingFileIO
{
    public class Program
    {
        static void Main(string[] args)
        {

            Contacts newContact = new Contacts("Shiva", "Barela", "GERMANY", "7869054332", "shiva37@gmail.com");
            Contacts newContact2 = new Contacts("vinnu", "Pawra", "INDIA", "988765465", "Vinnu243@gmail.com");

            string path = @"C:\Users\Shiva027\Desktop\NewRemapSession\AddressBookUsingFileIO\AddressBookUsingFileIO\Example.txt";
            string path2 = @"C:\Users\Shiva027\Desktop\NewRemapSession\AddressBookUsingFileIO\AddressBookUsingFileIO\CsvData.csv";
            string path3 = @"C:\Users\Shiva027\Desktop\NewRemapSession\AddressBookUsingFileIO\AddressBookUsingFileIO\ExportTo.json";

            AddressBook myAddressBook = new AddressBook();
            myAddressBook.AddContact(newContact);
            myAddressBook.AddContact(newContact2);
            Console.WriteLine("1:Write To File \n 2:Read From File \n 3:Write To Csv File \n4: Write To Json File \n5: Read From Json");
            Console.WriteLine("Enter the choice");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {                         
                        myAddressBook.WriteToFile(path);
                        myAddressBook.PrintContacts();
                        break;
                    }
                case 2:
                    {
                        myAddressBook.ReadFromFile(path);
                        break;
                    }
                case 3:
                    {
                        myAddressBook.ExportToCsv(path2);
                        break;
                    }
                case 4:
                    {
                        myAddressBook.WriteToJsonFile(path3);
                        break;
                    }
                case 5:
                    {
                        myAddressBook.ReadFromJsonFile(path3);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Please insert valid input");
                        break;
                    }
            }
            Console.ReadLine();

        }
    }
}
