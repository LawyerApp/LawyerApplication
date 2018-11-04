using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models
{
    public class ContactsViewModel
    {
        public string Number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public MessageSendModel Message { get; set; }
    }
}
