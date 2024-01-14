using LarTechAPi.Domain.Validations;

namespace LarTechAPi.Domain.Entities
{
    public sealed class Person
    {
        public Person(string name, string cpf, DateTime birthday, bool isActive)
        {
            ValidateDomain(name, cpf, birthday, isActive);
        }

        public Person(int id, string name, string cpf, DateTime birthday, bool isActive)
        {
            DomainExceptionValidation.When(id <= 0, "valor de Id inválido.");
            Id = id;
            ValidateDomain(name, cpf, birthday, isActive);
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<Phone> Phones { get; set; }

        public void StatusUpdate(bool isActive)
        {
            IsActive = isActive;
        }

        private void ValidateDomain(string name, string cpf, DateTime birthday, bool isActive)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Name invalid");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "Cpf is required");
            DomainExceptionValidation.When(cpf.Length != 11, "Cpf invalid");

            DomainExceptionValidation.When(birthday == null, "Birthday is required");
            DomainExceptionValidation.When(birthday > DateTime.Now, "Birthday invalid");

            DomainExceptionValidation.When(isActive == null, "Status is required");

            Name = name;
            Cpf = cpf;
            Birthday = birthday;
            IsActive = isActive;
        }
    }
}
