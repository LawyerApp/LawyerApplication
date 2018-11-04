using System.Collections.Generic;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class ContactEditModel
    {
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public List<ContactMap> ContactAdresses { get; set; }
    }
}
