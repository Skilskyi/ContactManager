using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using ContactManager.Application.Services;
using ContactManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;

namespace ContactManager.Controllers;

public class ContactController : Controller
{
    private readonly ContactService _contactService;

    public ContactController(ContactService contactService)
    {
        _contactService = contactService;
    }

    public async Task<IActionResult> Index()
    {
        var contacts = await _contactService.GetAllContactsAsync();
        return View(contacts);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            await _contactService.AddContactAsync(contact);
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contact = await _contactService.GetContactByIdAsync(id.Value);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Contact contact)
    {
        if (id != contact.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _contactService.UpdateContactAsync(contact);
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contact = await _contactService.GetContactByIdAsync(id.Value);
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _contactService.DeleteContactAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> UploadCsv(IFormFile file)
    {
        using var stream = new StreamReader(file.OpenReadStream());
        var csvReader = new CsvReader(stream, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));
        var records = csvReader.GetRecords<Contact>().ToList();

        await _contactService.AddContactsFromCsvAsync(records);

        return RedirectToAction(nameof(Index));
    }
}
