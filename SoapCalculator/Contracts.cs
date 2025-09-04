using System.ServiceModel;
using SoapCalculator.Dtos;

namespace SoapCalculator;


[ServiceContract(Namespace = "http://tempuri.org/")]
public class CalculatorService
{

    [OperationContract(Name = "loginRequestMethod")]
    public string LoginRequestMethod(SoapBody<LoginRequest> input)
    {
        return $"success {input.Request.Password} {input.Request.Username}";
    }
}
