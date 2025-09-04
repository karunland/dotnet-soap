using System.Runtime.Serialization;
using System.ServiceModel;

namespace SoapCalculator.Dtos;

[DataContract(Namespace = "http://tempuri.org/")]
public class LoginRequest
{
	[DataMember(Name = "password2", Order = 2)]
	public string Password2 { get; set; } = string.Empty;
	[DataMember(Name = "username2", Order = 1)]
	public string Username2 { get; set; } = string.Empty;
	[DataMember(Name = "anotherRequest", Order = 3)]
	public NestedClass AnotherRequest { get; set; } = new();
}

[DataContract(Namespace = "http://tempuri.org/")]
public class NestedClass
{
	[DataMember(Name = "password")]
	public string NestedPassword { get; set; } = string.Empty;
	[DataMember(Name = "username")]
	public string NestedUsername { get; set; } = string.Empty;
}

[MessageContract(IsWrapped = false)]
public class SoapBody<T> where T : class, new()
{
	[MessageBodyMember]
	public T Request { get; set; } = new();
}