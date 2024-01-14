using LarTechAPi.Domain.Entities;
using LarTechAPi.Domain.Validations;
using System.Reflection.Metadata;

namespace LarTechApi.XUnitTests.Domain.Entities
{
    public class PersonTest
    {
        [Fact(DisplayName = "Não deve criar pessoa sem CPF")]
        public void CreatePerson_Person_DontCreatePersonWithoutCPF()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() => 
                            new Person("Testando ABC", "", new DateTime(1996, 01, 01), false));

            Assert.Equal("Cpf is required", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar pessoa com CPF inválido")]
        public void CreatePerson_Person_DontCreatePersonWithInvalidCPF()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                            new Person("Testando ABC", "123456789101112", new DateTime(1996, 01, 01), false));

            Assert.Equal("Cpf invalid", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar pessoa com ID inválido")]
        public void CreatePerson_Person_DontCreatePersonWithInvalidId()
        {
            var ex = Assert.Throws<DomainExceptionValidation>(() =>
                            new Person(0, "Testando ABC", "123456789101112", new DateTime(1996, 01, 01), false));

            Assert.Equal("valor de Id inválido.", ex.Message);
        }

        [Fact(DisplayName = "Deve criar pessoa sem Id")]
        public void CreatePerson_Person_CreatePersonWithoutId()
        {
            var person = new Person("Testando ABC", "12345678910", new DateTime(1996, 01, 01), true);

            Assert.NotNull(person);
        }

        [Fact(DisplayName = "Deve criar pessoa com Id")]
        public void CreatePerson_Person_CreatePersonWithId()
        {
            var person = new Person(1, "Testando ABC", "12345678910", new DateTime(1996, 01, 01), true);

            Assert.NotNull(person);
        }
    }
}
