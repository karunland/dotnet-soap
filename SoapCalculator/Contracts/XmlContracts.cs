using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;
using SoapCalculator.Dtos;
using SoapCalculator.PaymentGeneratedModels;

namespace SoapCalculator;

[ServiceContract(Namespace = "https://payment.fairfinansman.com.tr/")]
public class XmlContracts
{

    [OperationContract(Name = "loginMethodXml")]
    public string LoginRequestMethodXml(SoapBodyXml<LoginRequestXml> input)
    {
        return $"success {input.Request.AnotherRequest.NestedPassword} {input.Request.AnotherRequest.NestedUsername} \n {input.Request.Password2} {input.Request.Username2}";
    }

    [OperationContract(Name = "reconciliateRequest")]
    public string ReconciliateRequestXml(SoapBodyXml<ReconciliateRequest> input)
    {
        if (input?.Request?.Arg0 == null)
        {
            throw new ArgumentNullException("Input or Arg0 is null");
        }
        return $"success {input.Request.Arg0.ReconDate} {input.Request.Arg0.ReconType}";
    }

    [OperationContract(Name = "method")]
    public LoginRequestXml2 LoginRequestXml2(LoginRequestXml2 input)
    {
        // Echo back the input with some processing
        return new LoginRequestXml2
        {
            Username = $"Processed_{input?.Username ?? "null"}",
            Password = $"Processed_{input?.Password ?? "null"}"
        };
    }
}


[XmlRoot(Namespace = "https://payment.fairfinansman.com.tr/", ElementName = "method")]
public class LoginRequestXml2
{
    [XmlElement("username")]
    public string Username { get; set; } = string.Empty;
    
    [XmlElement("password")]
    public string Password { get; set; } = string.Empty;
}