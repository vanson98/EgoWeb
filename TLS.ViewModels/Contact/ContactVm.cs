﻿using System;
using System.Collections.Generic;
using System.Text;
using TLS.ViewModels.DataTable;

namespace TLS.ViewModels.Contact
{
    public class ContactVm : DataTableRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string CreatedDate { get; set; }
    }
}
