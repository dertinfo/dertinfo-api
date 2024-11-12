using DertInfo.Models.DataTransferObject;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DertInfo.Services
{
    public class dodgyService
    {
        public ILogger<dodgyService> _logger { get; }
        public const string MY_KEY = "YkyoOH^NqRAm24&f";

        public dodgyService(ILogger<dodgyService> logger)
        {
            _logger = logger;
        }

        public async void doSomefinDodgy(FodgydataDto data)
        {
            // This is a dodgy method that does something dodgy
            // It is here to test the automated code review
            // It is not to be used in production
            // It is not to be used in any code that is to be reviewed by a human

                _logger.LogInformation($"Credit Card data {data.CardNumber}");

            _logger.LogInformation($"Key {MY_KEY}");
        }
    }
}
