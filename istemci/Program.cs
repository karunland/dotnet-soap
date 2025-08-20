using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;

namespace SoapClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // SOAP Client oluştur
                var binding = new BasicHttpBinding();
                var endpoint = new EndpointAddress("http://localhost:5000/Calculator.asmx");
                var client = new CalculatorClient(binding, endpoint);

                Console.WriteLine("=== SOAP Calculator Client ===\n");

                // Toplama işlemi
                var toplamaRequest = new SunucuRequest { Sayi1 = 10, Sayi2 = 5 };
                var toplamaSonuc = client.Topla(toplamaRequest);
                Console.WriteLine($"Toplama: {toplamaRequest.Sayi1} + {toplamaRequest.Sayi2} = {toplamaSonuc.Sonuc}");

                // Çıkarma işlemi
                var cikarmaRequest = new SunucuRequest { Sayi1 = 15, Sayi2 = 7 };
                var cikarmaSonuc = client.Cikar(cikarmaRequest);
                Console.WriteLine($"Çıkarma: {cikarmaRequest.Sayi1} - {cikarmaRequest.Sayi2} = {cikarmaSonuc.Sonuc}");

                // Hata durumu testi
                try
                {
                    var hataliRequest = new SunucuRequest { Sayi1 = 3, Sayi2 = 10 };
                    var hataliSonuc = client.Cikar(hataliRequest);
                }
                catch (FaultException ex)
                {
                    Console.WriteLine($"Hata yakalandı: {ex.Message}");
                }

                Console.WriteLine("\nİşlemler tamamlandı!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
    }

    // ---- SOAP Client Proxy ----
    public class CalculatorClient : ClientBase<ICalculatorService>, ICalculatorService
    {
        public CalculatorClient(Binding binding, EndpointAddress remoteAddress)
            : base(binding, remoteAddress) { }

        public SunucuResponse Topla(SunucuRequest request) => Channel.Topla(request);
        public SunucuResponse Cikar(SunucuRequest request) => Channel.Cikar(request);
    }

    // ---- Service Contract ----
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract] 
        SunucuResponse Topla(SunucuRequest request);
        
        [OperationContract] 
        SunucuResponse Cikar(SunucuRequest request);
    }

    // ---- Data Contracts ----
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
}
