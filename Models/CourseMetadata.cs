using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.MVC.Data;

public class CourseMetadata
{
    [Display(Name = "Course Name")]
    public string Name { get; set; } = null!;

    [Display(Name = "Course Code")]
    public string? Code { get; set; }

    [Display(Name = "Credits")]
    public int? Credits { get; set; }
}

[ModelMetadataType(typeof(CourseMetadata))]
public partial class Course
{
}