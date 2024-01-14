using LarTechAPi.Domain.Entities;
using LarTechAPi.Domain.Validations;

namespace LarTechApi.XUnitTests.Domain.Entities
{
    public class PhoneTest
    {
        [Fact(DisplayName = "Não deve criar telefone com Id inválido")]
        public void CreatePerson_Person_DontCreatePhoneWithInvalidId()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                            new Phone(0, "comercial", "4199999999", 1));

            Assert.Equal("Invalid ID", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar telefone sem Tipo")]
        public void CreatePerson_Person_DontCreatePhoneWithoutPhoneType()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                            new Phone(1, "", "4199999999", 1));

            Assert.Equal("Phone type is required", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar telefone com Tipo inválido")]
        public void CreatePerson_Person_DontCreatePhoneWithInvalidPhoneType()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                            new Phone(1, "ex", "4199999999", 1));

            Assert.Equal("Phone type invalid", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar telefone sem Número")]
        public void CreatePerson_Person_DontCreatePhoneWithoutPhoneNumber()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                            new Phone("residencial", "", 1));

            Assert.Equal("Phone number is required", ex.Message);
        }

        [Fact(DisplayName = "Deve criar telefone")]
        public void CreatePerson_Person_CretePhoneWithId()
        {
            var phone = new Phone(1, "residencial", "11999999999", 1);

            Assert.NotNull(phone);
        }

        [Fact(DisplayName = "Deve criar telefone sem Id")]
        public void CreatePerson_Person_CreatePhoneWithoutId()
        {
            var phone = new Phone("residencial", "11999999999", 1);

            Assert.NotNull(phone);
        }
    }
}
