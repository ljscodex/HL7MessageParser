using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7MessageParser.Interfases;
using HL7MessageParser.Models;
using NHapi.Base.Model;

namespace HL7MessageParser.Services
{
    public class PatientService : IPatient
    {
        public PatientModel getPatientInfo(NHapi.Base.Model.IMessage Message)
        {

            if (Message is not NHapi.Model.V23.Message.ORU_R01)
            {
                throw new Exception("Message has not the right type ");

            }

            var ParseMessage = (NHapi.Model.V23.Message.ORU_R01)Message;

            PatientModel patient = new PatientModel();
            try
            {
                var patientInfo = ParseMessage.GetRESPONSE().PATIENT.PID;

                if (patientInfo != null)
                {
                    patient.ID = patientInfo.GetPatientIDInternalID()[0].ID.Value;


                    var Address = patientInfo.GetPatientAddress();


                    if (Address.Any())
                    {
                        PatientAddressModel patientAddress = new PatientAddressModel();

                        patientAddress.City = Address[0].City.Value;
                        patientAddress.Country = Address[0].Country.Value;
                        patientAddress.Street = Address[0].StreetAddress.Value;
                        patientAddress.PostalCode = Address[0].ZipOrPostalCode.Value;
                        patientAddress.State = Address[0].StateOrProvince.Value;
                        patientAddress.CountyCode = Address[0].CountyParishCode.Value;
                        patient.Address = patientAddress;
                    }

                    patient.ExtenalID = patientInfo.PatientIDExternalID.ID.Value;

                    patient.SSNNumber = patientInfo.SSNNumberPatient.Value;

                    patient.DriverLicenseNumber = patientInfo.DriverSLicenseNumber.DriverSLicenseNumber.Value;

                    patient.Sex = patientInfo.Sex.Value;

                    patient.BirthDate = new DateTime(
                        patientInfo.DateOfBirth.TimeOfAnEvent.Year,
                        patientInfo.DateOfBirth.TimeOfAnEvent.Month,
                        patientInfo.DateOfBirth.TimeOfAnEvent.Day,
                        patientInfo.DateOfBirth.TimeOfAnEvent.Hour,
                        patientInfo.DateOfBirth.TimeOfAnEvent.Minute,
                        patientInfo.DateOfBirth.TimeOfAnEvent.Second
                        );


                    var Names = patientInfo.GetPatientName();
                    if (Names.Any())
                    {
                        PatientNameModel patientName = new PatientNameModel();

                        patientName.GivenName = Names[0].GivenName.ToString();
                        patientName.FamilyName = Names[0].FamilyName.ToString();
                        patientName.MiddleName = Names[0].MiddleInitialOrName.ToString();
                        patient.Name = patientName;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Patient Info Parsing Problem: " + ex.Message);
            }
            return patient;
        }

    }
}
