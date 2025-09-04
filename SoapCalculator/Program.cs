using SoapCore;
using SoapCalculator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddSingleton<CalculatorService>();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
	_ = endpoints.UseSoapEndpoint<CalculatorService>("/Calculator.asmx",
		new SoapEncoderOptions(),
		SoapSerializer.DataContractSerializer);
});

app.Run();