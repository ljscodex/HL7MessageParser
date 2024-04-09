using HL7MessageParser.Interfases;
using HL7MessageParser.Models;
using NHapi.Base.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7MessageParser.Services
{
    public class ParseService: IHL7Message
    {
        public HL7MessageModel ParseMessage(string Message)
        {
            var parser = new PipeParser();
            HL7MessageModel hL7Data = new HL7MessageModel();

            try
            {

                var message = parser.Parse(Message);
                if (message is null)
                {
                    throw new Exception("Unknow HL7 Parsing Problem");

                }
                PatientService _patient = new PatientService();

                hL7Data.Patient = _patient.getPatientInfo(message);

            }
            catch (Exception ex)
            {
                throw new Exception("Parsing Message Problem: " + ex.Message);
            }
            return hL7Data;
        }
    }
}
