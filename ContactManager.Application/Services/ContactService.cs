using ContactManager.Domain.Entities;
using ContactManager.Domain.Interfaces;
using System.Globalization;
using System;

namespace ContactManager.Application.Services;

public class ContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return _contactRepository.GetAllContactsAsync();
    }

    public Task<Contact> GetContactByIdAsync(int id)
    {
        return _contactRepository.GetContactByIdAsync(id);
    }

    public Task AddContactAsync(Contact contact)
    {
        return _contactRepository.AddContactAsync(contact);
    }

    public Task UpdateContactAsync(Contact contact)
    {
        return _contactRepository.UpdateContactAsync(contact);
    }

    public Task DeleteContactAsync(int id)
    {
        return _contactRepository.DeleteContactAsync(id);
    }
    public async Task AddContactsFromCsvAsync(IEnumerable<Contact> contacts)
    {
        await _contactRepository.AddRangeAsync(contacts);
        await _contactRepository.SaveChangesAsync();
    }
}
