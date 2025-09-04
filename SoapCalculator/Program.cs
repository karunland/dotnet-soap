using System.ServiceModel;
using SoapCore;
using System.Xml.Serialization;
using System.Runtime.Serialization;

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

[ServiceContract(Namespace = "http://tempuri.org/")]
class CalculatorService
{
    [OperationContract(Name = "loginRequestMethod")]
    string loginRequestMethod(Request request)
        => $"success {request.Password} {request.Username}";
}

[DataContract(Namespace = "http://tempuri.org/")]
class Request
{
    [DataMember(Name = "password", Order = 1)]
    public string Password { get; set; } = string.Empty;
    [DataMember(Name = "username", Order = 2)]
    public string Username { get; set; } = string.Empty;

}