using System;
using System.Collections.Generic;
using System.Linq;
using TestWebApi.Domain;
using TestWebApi.Domain.Entities;
using TestWebApi.Helpers;

namespace TestWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly DataContext _context;

        public ContactService(DataContext context)
        {
            _context = context;
        }

        // Get all contacts
        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts;
        }

        // Retrieve a particular contact with given contact ID
        public Contact GetById(int id)
        {
            return _context.Contacts.Find(id);
        }

        // Create a contact
        public Contact Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact;
        }

        // Delete a contact by contact ID
        public void Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }
    }
}