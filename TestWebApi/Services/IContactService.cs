using System.Collections.Generic;
using TestWebApi.Domain.Entities;

namespace TestWebApi.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
        Contact GetById(int id);
        Contact Create(Contact contact);
        void Delete(int id);
    }
}