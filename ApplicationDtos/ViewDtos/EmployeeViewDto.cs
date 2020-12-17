using ApplicationDomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos.ViewDtos
{
    public class EmployeeViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public uint Salary { get; set; }
        public CurrencyType Currency { get; set; }
        public List<PhoneNubmerViewDto> Numbers { get; set; }
    }
}
