﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace homework1.Models
{
    public partial class Person
    {
        public Person()
        {
            CourseInstructor = new HashSet<CourseInstructor>();
            Department = new HashSet<Department>();
            Enrollment = new HashSet<Enrollment>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HireDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EnrollmentDate { get; set; }
        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        [InverseProperty("Instructor")]
        public virtual OfficeAssignment OfficeAssignment { get; set; }
        [InverseProperty("Instructor")]
        public virtual ICollection<CourseInstructor> CourseInstructor { get; set; }
        [InverseProperty("Instructor")]
        public virtual ICollection<Department> Department { get; set; }
        [InverseProperty("Student")]
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public DateTime? DateModified { get; set; }
        public bool? IsDeleted { get; set; }
    }
}