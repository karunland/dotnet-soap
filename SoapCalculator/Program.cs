using SoapCore;
using SoapCalculator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddSingleton<DataContractServices>();
builder.Services.AddSingleton<XmlContracts>();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
	_ = endpoints.UseSoapEndpoint<DataContractServices>("/DataContract.asmx",
		new SoapEncoderOptions(),
		SoapSerializer.DataContractSerializer);
	_ = endpoints.UseSoapEndpoint<XmlContracts>("/XmlContract.asmx",
		new SoapEncoderOptions(),
		SoapSerializer.XmlSerializer);
});

app.Run();