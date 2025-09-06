using System.ServiceModel;
using SoapCalculator.Dtos;
using SoapCalculator.PaymentGeneratedModels;

namespace SoapCalculator;

[ServiceContract(Namespace = "https://payment.fairfinansman.com.tr/")]
public class DataContractServices
{

    [OperationContract(Name = "loginMethod")]
    public string LoginMethod(SoapBody<LoginRequest> input)
    {
        return $"success {input.Request.AnotherRequest.NestedPassword} {input.Request.AnotherRequest.NestedUsername} \n {input.Request.Password2} {input.Request.Username2}";
    }

    [OperationContract(Name = "reconciliateRequest")]
    public string ReconciliateRequest(SoapBody<ReconciliateRequest> input)
    {
        if (input?.Request?.Arg0 == null)
        {
            throw new ArgumentNullException("Input or Arg0 is null");
        }
        return $"success {input.Request.Arg0.ReconDate} {input.Request.Arg0.ReconType}";
    }
}
