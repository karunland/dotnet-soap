using System.ServiceModel;
using System.Runtime.Serialization;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Service'i interface üzerinden ekliyoruz
builder.Services.AddSingleton<ICalculatorService, CalculatorService>();

// SoapCore için gerekli servisler
builder.Services.AddSoapCore();

var app = builder.Build();
app.UseRouting();
// wsdl
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ICalculatorService>("/Calculator.asmx",
        new SoapEncoderOptions(),
        SoapSerializer.DataContractSerializer);
    
    // WSDL için ayrı endpoint
    endpoints.UseSoapEndpoint<ICalculatorService>("/Calculator.wsdl",
        new SoapEncoderOptions(),
        SoapSerializer.DataContractSerializer);
});

app.Urls.Add("http://localhost:5000");
app.Run();

// ---- Service Contract ----
[ServiceContract]
public interface ICalculatorService
{
    [OperationContract]
    SunucuResponse Topla(SunucuRequest request);

    [OperationContract]
    SunucuResponse Cikar(SunucuRequest request);
}

// ---- Service Implementation ----
public class CalculatorService : ICalculatorService
{
    public SunucuResponse Topla(SunucuRequest request)
    {
        if (request == null)
            throw new FaultException("Request null olamaz.");
            
        return new SunucuResponse { Sonuc = request.Sayi1 + request.Sayi2 };
    }

    public SunucuResponse Cikar(SunucuRequest request)
    {
        if (request == null)
            throw new FaultException("Request null olamaz.");
            
        if (request.Sayi1 < request.Sayi2)
            throw new FaultException("Sayi1, sayi2'den küçük olamaz.");

        return new SunucuResponse { Sonuc = request.Sayi1 - request.Sayi2 };
    }
}

// ---- Data Contracts ----
[DataContract(Namespace = "http://tempuri.org/")]
public record SunucuRequest
{
    [DataMember] public int Sayi1 { get; set; }
    [DataMember] public int Sayi2 { get; set; }
}

[DataContract(Namespace = "http://tempuri.org/")]
public record SunucuResponse
{
    [DataMember] public int Sonuc { get; set; }
}