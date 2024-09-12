using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Domain.Entities;

public class Contact
{
    [Ignore]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name and Surname")]
    public string Name { get; set; } = default!;

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Date is required")]
    [Display(Name = "Date of birth")]
    public DateTime DateOfBirth { get; set; }

    [Display(Name = "Family status")]
    public bool IsMarried { get; set; }

    [Phone]
    [Required(ErrorMessage = "Phone number is required")]
    public string Phone { get; set; } = default!;

    [Range(0, 1000000)]
    public decimal Salary { get; set; }
}
