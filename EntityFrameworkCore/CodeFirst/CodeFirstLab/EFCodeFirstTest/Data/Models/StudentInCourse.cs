﻿namespace EFCodeFirstTest.Data.Models
{
    using System;

    public class StudentInCourse
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
