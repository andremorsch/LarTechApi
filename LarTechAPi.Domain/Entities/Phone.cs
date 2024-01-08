using LarTechAPi.Domain.Validations;

namespace LarTechAPi.Domain.Entities
{
    public sealed class Phone
    {
        public Phone(string phoneType, string phoneNumber)
        {
            ValidateDomain(phoneType, phoneNumber);
        }
        public Phone(int id, string phoneType, string phoneNumber)
        {
            DomainExceptionValidation.When(id < 0, "valor de Id inválido.");
            Id = id;
            ValidateDomain(phoneType, phoneNumber);
        }

        public int Id { get; private set; }
        public string PhoneType { get; private set; }
        public string PhoneNumber { get; private set; }

        private void ValidateDomain (string phoneType, string phoneNumber)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(phoneType), "Phone type is required");
            DomainExceptionValidation.When(phoneType.Length < 3, "Phone type invalid");

            DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber), "Phone number is required");
            DomainExceptionValidation.When(phoneType.Length != 10 || phoneType.Length != 11, "Phone number invalid");

            PhoneType = phoneType;
            PhoneNumber = phoneNumber;
        }
    }
}
