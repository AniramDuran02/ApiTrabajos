using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
        List<Person> _persons;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }

        // retornar todos los valores
        public IEnumerable<Person> GetAll()
        {
            var query = _persons.Select(person => person);
            return query;
        }

        // retornar campos especificos
        public IEnumerable<Object> GetField()
        {
            var query = _persons.Select(Person => new {
            NombreCompleto = $"{Person.FirstName} {Person.LastName}",
            AnioNacimiento = DateTime.Now.AddYears(Person.Age * -1).Year,
            correoElectronico = Person.Email
        });

        return query;
        }

        // retornar elementos que sean iguales
        public IEnumerable<Person> GetByGender(char gender)
        {
            
            var query = _persons.Where(person => person.Gender == gender);
            return query;
        }

        public IEnumerable<Person> GetByMaxAge(int age)//Aqui recibo/solicito un valor para poder funcionar
        { //Si no recibo un valor no puedo funcionar y marca error
            
            var query = _persons.Where(person => person.Age > age);
            return query;
        }
        // Retornar elementos que sean diferentes
        public IEnumerable<Person> GetDiferences(string job )
            {
                
                var query = _persons.Where(Person => Person.Job != job);
                return query;
            }

            public IEnumerable<string> GetJobs()
            {
                var query = _persons.Select(Person => Person.Job).Distinct();
                return query;
            }
        
        // retornar valores que contengan
        public IEnumerable<Person> GetContains(string partName)
        {
            var query = _persons.Where(Person => Person.FirstName.Contains(partName));
            return query;
        }

        public IEnumerable<Person> GetByAges()
        {
            var ages = new List<int>{25,35,45};
            var query = _persons.Where(Person => ages.Contains(Person.Age));
            return query;
        }
        
        // retornar valores entre un rango
        public IEnumerable<Person> GetByRangeAge(int minAge, int maxAge)
        {
            

            var query = _persons.Where(Person => Person.Age > minAge && Person.Age < maxAge);
            return query;
        }
        
        // retornar elementos ordenados
        public IEnumerable<Person> GetPersonsOrdered(int age)

        {

            var query = _persons.Where(person => person.Age>age).OrderBy(person => person.Age);

            return query;

        }

        public IEnumerable<Person> GetPersonOrderedDesc(string job)
        {
            var query = _persons.Where(Person => Person.Job == job).OrderByDescending(Person => Person.Age);
            return query;
        }
        
        // retorno cantidad de elementos
        public int CountPeople(int age)
        {
            
            var query =_persons.Count(Person => Person.Age == age);
            return query;
        }
        // Evalua si un elemento existe
        public bool ExistPerson(string lastName)

        {

            var query=_persons.Exists(person => person.LastName==lastName);

            return query;

        }
        // retornar solo un elemento

        public Person GetPerson(string job, int age)

        {

            var query=_persons.FirstOrDefault(person=>person.Job==job && person.Age==age);



            return query;

        }


        public IEnumerable<Person> TakePeople(string job, int take)

        {

            var query = _persons.Where(person =>person.Job==job).Take(take);

            return query;

        }
        
        // retornar solamente unos elementos

        public IEnumerable<Person> SkipPeople(string job, int skip)

        {

            var query = _persons.Where(person =>person.Job==job).Skip(skip);

            return query;

        }
        
        // retornar elementos saltando posición
         public IEnumerable<Person> SkipTakePeople(string job, int skip, int take)

        {

            var query = _persons.Where(person =>person.Job==job).Skip(skip).Take(take);

            return query;

        }
        
    }
}