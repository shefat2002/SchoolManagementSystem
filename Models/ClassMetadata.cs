using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.MVC.Data;
public class ClassMetadata
{
    [Display(Name = "Class Time")]
    public DateTime Time { get; set; }

    [Display(Name = "Lecturer")]
    public int LecturerId { get; set; }

    [Display(Name = "Course")]
    public int CourseId { get; set; }
}

[ModelMetadataType(typeof(ClassMetadata))]
public partial class Class
{ }