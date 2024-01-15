using LarTechApi.XUnitTests.Infrastructure.Context;
using LarTechAPi.Domain.Entities;
using LarTechAPi.Infrastructure.Context;
using LarTechAPi.Infrastructure.Repositories;

namespace LarTechApi.XUnitTests.Infrastructure.Repositories
{
    public class PhoneRepositoryTest
    {
        private ApplicationDbContext _context;

        [Fact(DisplayName = "Deve salvar um telefone no DB")]
        public async Task Create_ShouldSaveAPhone()
        {
            var phone = new Phone(1, "comercial", "4799999999", 1);
            _context = DatabaseTestInMemory.GetDatabase();

            var phoneRepository = new PhoneRepository(_context);
            await phoneRepository.CreatePhoneAsync(phone);

            var result = _context.Phones.FirstOrDefault();
            Assert.NotNull(result);
            Assert.Equal(phone, result);
        }

        [Fact(DisplayName = "Deve deletar um telefone do DB")]
        public async Task Delete_ShouldDeleteAPhone()
        {
            var phone = new Phone(1, "comercial", "4799999999", 1);
            _context = DatabaseTestInMemory.GetDatabase();
            _context.Phones.Add(phone);
            await _context.SaveChangesAsync();

            var phoneRepository = new PhoneRepository(_context);
            await phoneRepository.DeletePhoneAsync(phone);

            var checkResult = _context.Phones.FirstOrDefault();
            Assert.Null(checkResult);
        }

        [Fact(DisplayName = "Deve retornar um telefone pelo Id")]
        public async Task Get_ShouldGetPhoneById()
        {
            var phone = new Phone(1, "comercial", "4799999999", 1);
            _context = DatabaseTestInMemory.GetDatabase();
            _context.Phones.Add(phone);
            await _context.SaveChangesAsync();

            var phoneRepository = new PhoneRepository(_context);
            var result = await phoneRepository.GetPhoneByIdAsync(1);

            Assert.Equal(phone, result);
            Assert.Equal(phone.Id, result.Id);
        }

        [Fact(DisplayName = "Deve retornar todos os telefones")]
        public async Task GetAll_ShouldGetPhones()
        {
            var phone1 = new Phone(1, "comercial", "4799999999", 1);
            var phone2 = new Phone(2, "residencial", "4188888888", 1);
            _context = DatabaseTestInMemory.GetDatabase();
            _context.Phones.Add(phone1);
            _context.Phones.Add(phone2);
            await _context.SaveChangesAsync();

            var phoneRepository = new PhoneRepository(_context);
            var result = await phoneRepository.GetPhonesAsync();

            Assert.True(result.Any());
            Assert.Equal(result.FirstOrDefault(x => x.Id == 1), phone1);
            Assert.Equal(result.FirstOrDefault(x => x.Id == 2), phone2);
        }
    }
}
