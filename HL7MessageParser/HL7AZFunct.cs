using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Dynamic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System;
using HL7MessageParser.Models;
using HL7MessageParser.Services;

namespace HL7MessageParser
{

    public class HL7AZFunct
    {
        private readonly ILogger<HL7AZFunct> _logger;

        public HL7AZFunct(ILogger<HL7AZFunct> logger)
        {
            _logger = logger;
        }

        [Function("HL7Parser")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("HL7 Patient Info Parser");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            try
            {
                ParseService _parser = new ParseService();

                var patientInfo = _parser.ParseMessage(requestBody);

                var result = JsonConvert.SerializeObject(patientInfo);

                return result == null
                  ? new BadRequestResult()
                  : new OkObjectResult(result);
            }
            catch ( Exception ex) 
            {
               return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}
