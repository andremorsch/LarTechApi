using LarTechAPi.Domain.Validations;

namespace LarTechAPi.Domain.Entities
{
    public sealed class Phone
    {
        public Phone(string phoneType, string phoneNumber, int personId)
        {
            ValidateDomain(phoneType, phoneNumber, personId);
        }
        public Phone(int id, string phoneType, string phoneNumber, int personId)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            Id = id;
            ValidateDomain(phoneType, phoneNumber, personId);
        }

        public int Id { get; private set; }
        public string PhoneType { get; private set; }
        public string PhoneNumber { get; private set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

        private void ValidateDomain (string phoneType, string phoneNumber, int personId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(phoneType), "Phone type is required");
            DomainExceptionValidation.When(phoneType.Length < 3, "Phone type invalid");

            DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber), "Phone number is required");

            DomainExceptionValidation.When(personId < 0, "Person id invalid");

            PhoneType = phoneType;
            PhoneNumber = phoneNumber;
            PersonId = personId;
        }
    }
}
