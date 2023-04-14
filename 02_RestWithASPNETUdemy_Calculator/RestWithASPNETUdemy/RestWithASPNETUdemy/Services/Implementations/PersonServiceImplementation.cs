using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonServices
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i< 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = id,
                FirstName = "Ricardo",
                LastName = "Sequeira",
                Address = "Mafra",
                Gender = "Male",

            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementeAndGet(),
                FirstName = "Ricardo" + i,
                LastName = "Sequeira" + i,
                Address = "Mafra" + i,
                Gender = "Male",

            };
        }

        private long IncrementeAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
