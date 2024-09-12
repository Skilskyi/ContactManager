using ContactManager.Domain.Entities;
using System;

namespace ContactManager.Domain.Interfaces;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllContactsAsync();
    Task<Contact> GetContactByIdAsync(int id);
    Task AddContactAsync(Contact contact);
    Task UpdateContactAsync(Contact contact);
    Task DeleteContactAsync(int id);
    Task AddRangeAsync(IEnumerable<Contact> contacts);
    Task SaveChangesAsync();
}
