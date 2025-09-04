using System.Runtime.Serialization;
using System.ServiceModel;
using SoapCalculator.Dtos;
using SoapCalculator.PaymentGeneratedModels;

namespace SoapCalculator;

[ServiceContract(Namespace = "http://tempuri.org/")]
public class CalculatorService
{

    [OperationContract(Name = "loginRequestMethod")]
    public string LoginRequestMethod(SoapBody<LoginRequest> input)
    {
        return $"success {input.Request.AnotherRequest.NestedPassword} {input.Request.AnotherRequest.NestedUsername} \n {input.Request.Password2} {input.Request.Username2}";
    }

    [OperationContract(Name = "reconciliateRequest")]
    public string ReconciliateRequest(SoapBody<ReconciliateRequest> input)
    {
        return $"success {input.Request.Arg0.ReconDate} {input.Request.Arg0.ReconType} {input.Request.Arg0.BankId} {input.Request.Arg0.BankUserName}";
    }
}
