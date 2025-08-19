## SOAP Calculator (ASP.NET Core + SoapCore)

Kısa bir SOAP servis örneği. `Topla` ve `Cikar` metodları vardır.

## Gereksinimler
- .NET SDK 9 yüklü

## Çalıştırma
- Sunucu: `dotnet run --project SoapCalculator`
- İstemci: `dotnet run --project istemci`

## SOAP Uç Noktası
- URL: `http://localhost:5000/Calculator.asmx`
- WSDL: `http://localhost:5000/Calculator.asmx?wsdl`

## Postman ile Test (Örnek İstek)
- Method: POST
- URL: `http://localhost:5000/Calculator.asmx`
- Headers: `Content-Type: text/xml; charset=utf-8`, `SOAPAction: "http://tempuri.org/ICalculatorService/Topla"`
- Body (raw):

```xml
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
               xmlns:xsd="http://www.w3.org/2001/XMLSchema"
               xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <Topla xmlns="http://tempuri.org/">
      <request>
        <Sayi1>1</Sayi1>
        <Sayi2>2</Sayi2>
      </request>
    </Topla>
  </soap:Body>
  
</soap:Envelope>
```

Beklenen yanıt: `Sonuc = 3`


