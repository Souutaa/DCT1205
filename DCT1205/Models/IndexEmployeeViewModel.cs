﻿using DCT1205.Entity;
using System.ComponentModel.DataAnnotations;

namespace DCT1205.Models
{
    public class IndexEmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }       
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime Designation { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        

    } 
}
