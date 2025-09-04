using System.Runtime.Serialization;
using System.ServiceModel;

namespace SoapCalculator.Dtos;

[DataContract(Namespace = "http://tempuri.org/")]
public class LoginRequest
{
	[DataMember(Name = "password")]
	public string Password { get; set; } = string.Empty;
	[DataMember(Name = "username")]
	public string Username { get; set; } = string.Empty;
	// [DataMember(Name = "anotherRequest")]
	// public AnotherRequest AnotherRequest { get; set; } = new();
}

[DataContract(Namespace = "http://tempuri.org/")]
public class AnotherRequest
{
	[DataMember(Name = "password2")]
	public string Password2 { get; set; } = string.Empty;
	[DataMember(Name = "username2")]
	public string Username2 { get; set; } = string.Empty;
}

[MessageContract(IsWrapped = false)]
public class SoapBody<T> where T : class, new()
{
	[MessageBodyMember(Name = "YourRequest")]
	public T Request { get; set; } = new();
}