using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.MVC.Data;

public class StudentMetadata
{

    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;
    [Display(Name = "Date of Birth")]
    public DateOnly? DateOfBirth { get; set; }
}

[ModelMetadataType(typeof(StudentMetadata))]
public partial class Student { }