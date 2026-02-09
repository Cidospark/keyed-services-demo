using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyedServiceDemo.Services
{
    public class FlutterwavePaymentService : IPaymentService
    {
         public string Name => "flutterwave";

        public Task<bool> IsHealthyAsync()
        {
            // Simulated health check
            return Task.FromResult(false);
        }
        public Task ProcessAsync(decimal amount)
        {
            Console.WriteLine($"Processing ₦{amount} via Flutterwave");
            return Task.CompletedTask;
        }
    }
}