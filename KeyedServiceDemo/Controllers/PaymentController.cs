using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KeyedServiceDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KeyedServiceDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly PaymentProcessorService _paymentProcessorService;

        public PaymentController(ILogger<PaymentController> logger, PaymentProcessorService processorService)
        {
            _logger = logger;
            _paymentProcessorService = processorService;
        }

        [HttpPost]   
        public async Task<IActionResult> Post(decimal amount)
        {
            await _paymentProcessorService.ProcessPaymentAsync(amount);
            return Ok("Done!");
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}