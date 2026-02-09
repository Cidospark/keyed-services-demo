using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyedServiceDemo.Services
{
    public class PaymentProviderSelector
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string[] _priorityOrder =
        {
            "flutterwave",
            "paystack"
        };

        public PaymentProviderSelector(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public async Task<IPaymentService> GetHealthyProviderAsync()
        {
            foreach (var key in _priorityOrder)
            {
                var provider = _serviceProvider.GetRequiredKeyedService<IPaymentService>(key);
                if (await provider.IsHealthyAsync())
                {
                    return provider;
                }
            }
            throw new InvalidOperationException("No healthy payment providers available");
        }
    }
}