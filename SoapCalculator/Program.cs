using System.ServiceModel;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<SunucuService>();
var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.UseSoapEndpoint<SunucuService>("/Servis.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.Run();

[ServiceContract]
public class SunucuService
{
    [OperationContract]
    public int Topla(int sayi1, int sayi2)
    {
        return sayi1 + sayi2;
    }
}