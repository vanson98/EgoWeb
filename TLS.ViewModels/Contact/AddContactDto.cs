using System;
using System.Collections.Generic;
using System.Text;

namespace TLS.ViewModels.Contact
{
    public class AddContactDto
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
