using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyedServiceDemo.Services
{
    public interface IPaymentService
    {
        string Name { get; }
        Task<bool> IsHealthyAsync();
        Task ProcessAsync(decimal amount);
    }
}