using System.ServiceModel;
using System.Runtime.Serialization;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SunucuService>();
var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.UseSoapEndpoint<SunucuService>("/Servis.asmx", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
});

app.Urls.Add("http://localhost:5000");
app.Run();

[ServiceContract]
public class SunucuService
{
    [OperationContract]
    SunucuResponse Topla(SunucuRequest request) => new SunucuResponse { Sonuc = request.Sayi1 + request.Sayi2 };
}

[DataContract]
public record SunucuRequest
{
    [DataMember]
    public int Sayi1 { get; set; }
    [DataMember]
    public int Sayi2 { get; set; }
}

[DataContract]
public record SunucuResponse
{
    [DataMember]
    public int Sonuc { get; set; }
}