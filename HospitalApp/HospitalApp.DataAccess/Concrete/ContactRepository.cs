using Hospital.Models;
using HospitalApp.DataAccess.Abstract;
using HospitalApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalApp.DataAccess.Concrete
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateContact(ContactViewModel contactViewModel)
        {
            var contact = contactViewModel.ConvertViewModel(contactViewModel);
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            
        }

        public void DeleteContact(int id)
        {
            var deleteContact = _context.Contacts.Find(id);

            if (deleteContact == null)
            {
                throw new KeyNotFoundException("Contact not found.");
            }
            _context.Contacts.Remove(deleteContact);
            _context.SaveChanges();
        }

        public List<ContactViewModel> GetAll()
        {
            var contacts = _context.Contacts.ToList();
            var contactViewModels = contacts.Select(h => new ContactViewModel(h)).ToList();
            return contactViewModels;
        }

        public List<ContactViewModel> GetAll(string IncludeProperties)
        {
            IQueryable<Contact> query = _context.Contacts;

            foreach (var includeProperty in IncludeProperties.Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var contacts = query.ToList();
            var contactViewModels = contacts.Select(r => new ContactViewModel(r)).ToList();
            return contactViewModels;
        }
       public ContactViewModel GetContactGetById(int ContactId)
        {
            var contact = _context.Contacts.Find(ContactId);
            if (contact == null)
            {
                return null;
            }
            return new ContactViewModel(contact);
        }

        public void UpdateContact(ContactViewModel contactViewModel)
        {
            var existingContact = _context.Contacts.Find(contactViewModel.Id);
            if (existingContact == null)
            {
                throw new KeyNotFoundException("Contact not found.");
            }

            existingContact.Email = contactViewModel.Email;
            existingContact.Phone = contactViewModel.Phone;
            existingContact.HospitalId = contactViewModel.HospitalId;

            _context.Contacts.Update(existingContact);
            _context.SaveChanges();
        }
    }
}
