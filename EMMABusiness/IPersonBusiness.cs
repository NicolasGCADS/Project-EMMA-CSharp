using EMMAModel;

namespace EMMABusiness
{
    public interface IPersonService
    {
        Task<Person?> GetByEmailAsync(string email);
        Task<Person?> ValidateCredentialsAsync(string email, string password);
        Task<Person> CreateAsync(string name, string email, string password, string role);

        
        List<Person> ListAll();
        Person? GetById(int id);
        Person Create(Person person);
        bool Update(Person person);
        bool Delete(int id);
    }
}
