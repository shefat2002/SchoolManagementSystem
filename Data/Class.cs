﻿using System;
using System.Collections.Generic;

namespace SchoolManagementSystem.MVC.Data;

public partial class Class
{
    public int Id { get; set; }

    public int? LecturerId { get; set; }

    public int? CourseId { get; set; }

    public TimeOnly? Time { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Lecturer? Lecturer { get; set; }
}
