using System;
using System.Threading.Tasks;
using OrangedataRequest;
using OrangedataRequest.DataService;
using OrangedataRequest.Models;
using OrangedataRequest.Enums;
using System.Linq;
using System.Collections.Generic;

namespace TestLauncher
{
    public class Example
    {
        static async Task Main(string[] args)
        {
            var prKeyPath = @"D:\Projects\OnlineKassa\Docs\git\API\files_for_test\private_key_test.xml";
            var certPath = @"D:\Projects\OnlineKassa\Docs\git\API\files_for_test\client.pfx";
            var certPass = "1234";

            var dummyOrangeRequest = new OrangeRequest(prKeyPath, certPath, certPass);

            ReqCreateCheck dummyCreateCheckRequest = new ReqCreateCheck
            {
                Id = "66549876224",
                INN = "7705721283",
                Key = "7705721283",
                Content = new Content
                {
                    Type = DocTypeEnum.In,
                    //AgentType = AgentTypeEnum.,
                    CheckClose = new CheckClose
                    {
                        Payments = new[]
                        {
                            new Payment
                            {
                                Amount = 123.00m,
                                Type = PaymentTypeEnum.Emoney
                            }
                        },
                        TaxationSystem = TaxationSystemEnum.Simplified
                    },
                    Positions = new[]
                    {
                        new Position
                        {
                            Price = 123.00m,
                            Quantity = 1m,
                            Tax = VATRateEnum.NONE,
                            Text = "Булка",
                            PaymentMethodType = PaymentMethodTypeEnum.Full,
                            PaymentSubjectType = PaymentSubjectTypeEnum.Product
                        }
                    },
                    TotalSum = 123.00m,
                    CustomerContact = "foo@example.com"
                }
            };

            List<Position> positions = dummyCreateCheckRequest.Content.Positions.ToList();
            List<Payment> payments = dummyCreateCheckRequest.Content.CheckClose.Payments.ToList();

            decimal summAmount = positions.Sum(position => position.Quantity*position.Price);
            decimal payAmount = payments.Sum(payment => payment.Amount);

            bool i = summAmount == payAmount;

            ReqCreateCorrectionCheck dummyCreateCorrectionCheckRequest = new ReqCreateCorrectionCheck
            {
                Id = "66549876219",
                INN = "7705721283",
                Key = "7705721283",
                Content = new CorrectionContent
                {
                    Type = DocTypeEnum.In,
                    CashSum = 2000,
                    TaxationSystem = TaxationSystemEnum.Common,
                    Tax4Sum = 2000,
                    CauseDocumentDate = DateTime.UtcNow.Date,
                    CauseDocumentNumber = "21"
                }
            };
            var res1 = await dummyOrangeRequest.CreateCheckAsync(dummyCreateCheckRequest);
            var res2 = await dummyOrangeRequest.GetCheckStateAsync("7705721283", "66549876224");
            var res3 = await dummyOrangeRequest.CreateCorrectionCheckAsync(dummyCreateCorrectionCheckRequest);
            var res4 = await dummyOrangeRequest.GetCorrectionCheckStateAsync("5001104058", "12345678990");
            Console.ReadKey();
        }
    }
}