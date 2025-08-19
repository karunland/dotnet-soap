using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;

var binding = new BasicHttpBinding();
var endpoint = new EndpointAddress("http://localhost:5000/Calculator.asmx");

// Proxy oluştur
var istemci = new Servis(binding, endpoint);

// Çağrılar
var sonuc = istemci.Topla(new SunucuRequest { Sayi1 = 1, Sayi2 = 2 });
Console.WriteLine("Topla Sonuç: " + sonuc.Sonuc);

var cikar = istemci.Cikar(new SunucuRequest { Sayi1 = 3, Sayi2 = 1 });
Console.WriteLine("Çıkar Sonuç: " + cikar.Sonuc);

// ---- Proxy Class ----
class Servis : ClientBase<ICalculatorService>, ICalculatorService
{
    public Servis(Binding binding, EndpointAddress remoteAddress)
        : base(binding, remoteAddress) { }

    public SunucuResponse Topla(SunucuRequest request) => Channel.Topla(request);
    public SunucuResponse Cikar(SunucuRequest request) => Channel.Cikar(request);
}

// ---- Service Contract (Client tarafı) ----
[ServiceContract]
public interface ICalculatorService
{
    [OperationContract] SunucuResponse Topla(SunucuRequest request);
    [OperationContract] SunucuResponse Cikar(SunucuRequest request);
}

// ---- Data Contracts ----
[DataContract]
public record SunucuRequest
{
    [DataMember] public int Sayi1 { get; set; }
    [DataMember] public int Sayi2 { get; set; }
}

[DataContract]
public record SunucuResponse
{
    [DataMember] public int Sonuc { get; set; }
}
