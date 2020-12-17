using ApplicationDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDomainModels.Models
{
    public class Employee : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string IdentityNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Nationality { get; set; }
        public uint Salary { get; set; }
        public CurrencyType Currency { get; set; }
        public IEnumerable<PhoneNumber> Numbers { get; set; }
    }
}
