using System.ServiceModel;
using System.ServiceModel.Channels;

var istemci = new Servis(new BasicHttpBinding(), new EndpointAddress("http://localhost:5000/Servis.asmx"));
Console.WriteLine(istemci.Topla(1, 2));

class Servis(Binding binding, EndpointAddress remoteAddress) : ClientBase<IServis>(binding, remoteAddress)
{
    public int Topla(int sayi1, int sayi2) => Channel.Topla(sayi1, sayi2);
}

[ServiceContract]
interface IServis
{
    [OperationContract]
    int Topla(int sayi1, int sayi2);
}