using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace SoapCalculator.Dtos;

[XmlRoot(Namespace = "https://payment.fairfinansman.com.tr/")]
public class LoginRequestXml
{
	[XmlElement("password2", Order = 2)]
	public string Password2 { get; set; } = string.Empty;
	[XmlElement("username2", Order = 1)]
	public string Username2 { get; set; } = string.Empty;
	[XmlElement("anotherRequest", Order = 3)]
	public NestedClassXml AnotherRequest { get; set; } = new();
}

[XmlRoot(Namespace = "https://payment.fairfinansman.com.tr/")]
public class NestedClassXml
{
    [XmlElement("password")]
	public string NestedPassword { get; set; } = string.Empty;
	[XmlElement("username")]
	public string NestedUsername { get; set; } = string.Empty;
}

[XmlRoot("SoapBody")]
public class SoapBodyXml<T> where T : class, new()
{
    [XmlElement("Request")]
    public T Request { get; set; } = new();
}