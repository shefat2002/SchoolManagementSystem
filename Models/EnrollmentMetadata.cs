using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.MVC.Data;

public class EnrollmentMetadata
{
    [Display(Name = "Student")]
    public int StudentId { get; set; }

    [Display(Name = "Class")]
    public int ClassId { get; set; }

    [Display(Name = "Grade")]
    public string? Grade { get; set; }
}

[ModelMetadataType(typeof(EnrollmentMetadata))]
public partial class Enrollment
{
    // The partial class is used to extend the functionality of the Enrollment class
    // without modifying the original class definition.
    // This allows for separation of concerns and better organization of code.
}