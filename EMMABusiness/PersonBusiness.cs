using Microsoft.EntityFrameworkCore;
using EMMAData;
using EMMAModel;

namespace EMMABusiness
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;

        public PersonService(AppDbContext context)
        {
            _context = context;
        }

      

        public async Task<Person?> GetByEmailAsync(string email)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<Person?> ValidateCredentialsAsync(string email, string password)
        {
            return await _context.Persons
                .FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
        }

        public async Task<Person> CreateAsync(string name, string email, string password, string role)
        {
            var person = new Person
            {
                Name = name,
                Email = email,
                Password = password,
                Role = role
            };

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return person;
        }

 

        public List<Person> ListAll() => _context.Persons.ToList();

        public Person? GetById(int id) => _context.Persons.Find(id);

        public Person Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }

        public bool Update(Person person)
        {
            var existing = _context.Persons.Find(person.IdPerson);
            if (existing == null) return false;

            existing.Name = person.Name;
            existing.Email = person.Email;
            existing.Password = person.Password;
            existing.Role = person.Role;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var person = _context.Persons.Find(id);
            if (person == null) return false;

            _context.Persons.Remove(person);
            _context.SaveChanges();
            return true;
        }
    }
}
