using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDtos.ViewDtos
{
    public class PhoneNubmerViewDto
    {
        public int Id { get; set; }
        public int CountryCode { get; set; }
        public int Number { get; set; }
        public string FullNumber => $"+({CountryCode}) {Number}";
    }
}
