using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = "Aislan Michel",
                LastName = "Moreira Freitas",
                Document = "99999999999",
                Email = "aislan.michel92@gmail.com",
                BarCode = "1132154",
                BoletoNumber = "1231321321",
                PaymentNumber = "298739823",
                PaidDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1),
                Total = 60,
                TotalPaid = 60,
                Payer = "AM4",
                PayerDocument = "123456789101",
                PayerDocumentType = Domain.Enums.EDocumentType.CPF,
                PayerEmail = "am4@am4.com",
                Street = "asdas",
                Number = "asdasd",
                Neighborhood = "asdasd",
                City = "asdasd",
                State = "woeiwe",
                Country = "aszlkçdjas",
                ZipCode = "27286390"
            };

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}
