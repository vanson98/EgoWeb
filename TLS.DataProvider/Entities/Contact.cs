﻿using System;
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
        public string Position { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string SolutionOfInterest { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}