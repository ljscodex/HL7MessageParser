using HL7MessageParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7MessageParser.Interfases
{
    public interface IHL7Message
    {

        public HL7MessageModel ParseMessage(string Message);

    }
}
