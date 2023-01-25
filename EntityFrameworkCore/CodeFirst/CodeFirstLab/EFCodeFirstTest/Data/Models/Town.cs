﻿namespace EFCodeFirstTest.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}