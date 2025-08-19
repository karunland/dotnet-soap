using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;

var istemci = new Servis(new BasicHttpBinding(), new EndpointAddress("http://localhost:5000/Servis.asmx"));
var sonuc = istemci.Topla(new SunucuRequest { Sayi1 = 1, Sayi2 = 2 });
Console.WriteLine(sonuc.Sonuc);

class Servis(Binding binding, EndpointAddress remoteAddress) : ClientBase<IServis>(binding, remoteAddress)
{
    public SunucuResponse Topla(SunucuRequest request) => Channel.Topla(request);
}

[ServiceContract]
interface IServis
{       
    [OperationContract]
    SunucuResponse Topla(SunucuRequest request);
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
