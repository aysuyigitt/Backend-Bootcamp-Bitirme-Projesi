using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalApp.DataAccess.Abstract
{
    public interface IContactRepository
    {
        List<ContactViewModel> GetAll(string IncludeProperties);

        ContactViewModel GetContactGetById(int ContactId); 

        void UpdateContact(ContactViewModel contactViewModel);

        void CreateContact(ContactViewModel contactViewModel);

        void DeleteContact(int id); 
    }
}
