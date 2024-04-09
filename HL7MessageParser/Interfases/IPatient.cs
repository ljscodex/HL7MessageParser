using HL7MessageParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7MessageParser.Interfases
{
    internal interface IPatient
    {

        public PatientModel getPatientInfo(NHapi.Base.Model.IMessage Message);

    }
}
