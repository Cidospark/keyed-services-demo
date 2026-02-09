using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyedServiceDemo.Services
{
    public class PaystackPaymentService : IPaymentService
    { 
        public string Name => "paystack";

        public Task<bool> IsHealthyAsync()
        {
            // Simulated health check
            return Task.FromResult(true);
        }
        
        public Task ProcessAsync(decimal amount)
        {
            Console.WriteLine($"Processing ₦{amount} via Paystack");
            return Task.CompletedTask;
        }
    }
}