using KeyedServiceDemo.Middleware;
using KeyedServiceDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddKeyedScoped<IPaymentService, PaystackPaymentService>("paystack");
builder.Services.AddKeyedScoped<IPaymentService, FlutterwavePaymentService>("flutterwave");
builder.Services.AddScoped<PaymentProviderSelector>();
builder.Services.AddScoped<PaymentProcessorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalExceptionHandler>();

await app.RunAsync();
