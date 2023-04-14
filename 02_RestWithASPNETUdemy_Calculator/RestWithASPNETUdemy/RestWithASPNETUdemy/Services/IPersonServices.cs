using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonServices
    {
        Person Create(Person person);
        Person FindByID(long ID);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);


    }
}
