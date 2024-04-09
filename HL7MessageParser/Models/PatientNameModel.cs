using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7MessageParser.Models
{

    public record PatientNameModel
    {
        public string GivenName { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
    }

}
