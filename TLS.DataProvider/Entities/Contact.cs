using System;
using System.Collections.Generic;
using System.Text;

namespace TLS.DataProvider.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessAreas { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}