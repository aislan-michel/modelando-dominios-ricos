using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTestes
    {
        //Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid() //should return when
        {
            var doc = new Document("123", EDocumentType.CNPJ);

            Assert.IsTrue(doc.Invalid); //garanta que é verdadeiro que meu documento é invalido
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid() 
        {
            var doc = new Document("15861482000141", EDocumentType.CNPJ);

            Assert.IsTrue(doc.Valid); //garanta que é verdadeiro que meu documento é valido
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid() 
        {
            var doc = new Document("123", EDocumentType.CPF);

            Assert.IsTrue(doc.Invalid); 
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCPFIsValid() 
        {
            var doc = new Document("19025561780", EDocumentType.CPF);

            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("19025561780")]
        [DataRow("86008257090")]
        [DataRow("30279088043")]
        [DataRow("63927107018")]
        [DataRow("61822019087")]
        public void TestarVariosCPFs(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);

            Assert.IsTrue(doc.Valid);
        }
    }
}
