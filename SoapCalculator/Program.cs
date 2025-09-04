using System.Runtime.Serialization;
using System.ServiceModel;
using SoapCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddSingleton<CalculatorService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
	_ = endpoints.UseSoapEndpoint<CalculatorService>("/Calculator.asmx",
		new SoapEncoderOptions(),
		SoapSerializer.DataContractSerializer);
});

app.Run();

[ServiceContract(Namespace = "http://tempuri.org/")]
class CalculatorService
{

	[OperationContract(Name = "loginRequestMethod")]
	string LoginRequestMethod(SoapBody<LoginRequest> input)
	{
		return $"success {input.Request.Password} {input.Request.Username}";
	}
}

[DataContract(Namespace = "http://tempuri.org/")]
class LoginRequest
{
	[DataMember(Name = "password")]
	public string Password { get; set; } = string.Empty;
	[DataMember(Name = "username")]
	public string Username { get; set; } = string.Empty;
	// [DataMember(Name = "anotherRequest")]
	// public AnotherRequest AnotherRequest { get; set; } = new();
}

[DataContract(Namespace = "http://tempuri.org/")]
class AnotherRequest
{
	[DataMember(Name = "password2")]
	public string Password2 { get; set; } = string.Empty;
	[DataMember(Name = "username2")]
	public string Username2 { get; set; } = string.Empty;
}

[MessageContract(IsWrapped = false)]
class SoapBody<T> where T : class, new()
{
	[MessageBodyMember(Name = "YourRequest")]
	public T Request { get; set; } = new();
}