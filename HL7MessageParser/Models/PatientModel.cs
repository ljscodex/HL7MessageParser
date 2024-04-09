using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7MessageParser.Models
{
    /*
///<li>PID-1: Set ID - PID (SI)</li>
///<li>PID-3: Patient Identifier List (CX)</li>
///<li>PID-4: Alternate Patient ID - PID (CX)</li>
///<li>PID-6: Mother's Maiden Name (XPN)</li>
///<li>PID-7: Date/Time Of Birth (TS)</li>
///<li>PID-8: Administrative Sex (IS)</li>
///<li>PID-9: Patient Alias (XPN)</li>
///<li>PID-10: Race (CE)</li>
///<li>PID-11: Patient Address (XAD)</li>
///<li>PID-12: County Code (IS)</li>
///<li>PID-13: Phone Number - Home (XTN)</li>
///<li>PID-14: Phone Number - Business (XTN)</li>
///<li>PID-15: Primary Language (CE)</li>
///<li>PID-16: Marital Status (CE)</li>
///<li>PID-17: Religion (CE)</li>
///<li>PID-18: Patient Account Number (CX)</li>
///<li>PID-21: Mother's Identifier (CX)</li>
///<li>PID-22: Ethnic Group (CE)</li>
///<li>PID-23: Birth Place (ST)</li>
///<li>PID-24: Multiple Birth Indicator (ID)</li>
///<li>PID-25: Birth Order (NM)</li>
///<li>PID-26: Citizenship (CE)</li>
///<li>PID-27: Veterans Military Status (CE)</li>
///<li>PID-28: Nationality (CE)</li>
///<li>PID-29: Patient Death Date and Time (TS)</li>
///<li>PID-30: Patient Death Indicator (ID)</li>
///<li>PID-31: Identity Unknown Indicator (ID)</li>
///<li>PID-32: Identity Reliability Code (IS)</li>
///<li>PID-33: Last Update Date/Time (TS)</li>
///<li>PID-34: Last Update Facility (HD)</li>
///<li>PID-35: Species Code (CE)</li>
///<li>PID-36: Breed Code (CE)</li>
*/


    public record PatientModel
    {
        public string ID { get; set; } = null!;
        public PatientAddressModel Address { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string DriverLicenseNumber { get; set; } = null!;
        public string ExtenalID { get; set; } = null!;
        public PatientNameModel Name { get; set; } = null!;
        public string ProductionClassCode { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public string SSNNumber { get; set; } = null!;

        public string Strain { get; set; } = null!;

    }

}
