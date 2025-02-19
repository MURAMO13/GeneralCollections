using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        //  создаём пустой список с типом данных Contact
        var phoneBook = new List<Contact>();

        // добавляем контакты
        phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
        phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
        phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
        phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
        phoneBook.Add(new Contact("Сергей", "Брин", 79990000013, "serg@example.com"));
        phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 79990000013, "innokentii@example.com"));

        var contactSortedbyName = phoneBook.OrderBy(contact => contact.Name);
        var contactSortedbyLastName = phoneBook.OrderBy(contact => contact.LastName);
        var cotactSortedbyNameAndLastName = phoneBook.OrderBy(contact => contact.Name).ThenBy(contact => contact.LastName);

        var contactSortedbyNameLinQ = from contact in phoneBook orderby contact.Name select contact;
        var contactSortedbyLastNameLinQ = from contact in phoneBook orderby contact.LastName select contact;
        var contactSortedbyNameAndLastNameLinQ = from contact in phoneBook orderby contact.Name, contact.LastName select contact;

        PrintContacts(contactSortedbyName);
        PrintContacts(contactSortedbyLastName);
        PrintContacts(cotactSortedbyNameAndLastName);

        PrintContacts(contactSortedbyNameLinQ);
        PrintContacts(contactSortedbyLastNameLinQ);
        PrintContacts(contactSortedbyNameAndLastNameLinQ);


    }

    static void PrintContacts(IEnumerable<Contact> contacts, [CallerArgumentExpression("contacts")] string contactsName="")
    {
        Console.WriteLine(contactsName+"\n");

        foreach (var contact in contacts)
        {
            Console.WriteLine($"===>{contact.Name} {contact.LastName} {contact.PhoneNumber} {contact.Email}");
        }
        Console.WriteLine("\n\n");
    }
}

public class Contact // модель класса
{
    public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
    {
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public String Name { get; }
    public String LastName { get; }
    public long PhoneNumber { get; }
    public String Email { get; }
}

