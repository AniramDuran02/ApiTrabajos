using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var repository = new PersonRepository();
            var persons = repository.GetAll();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Field")]
        public IActionResult GetField()
        {
            var repository = new PersonRepository();
            var persons = repository.GetField();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("ByGender/{gender}")]
        public IActionResult GetByGender(char gender)
        {
            var repository = new PersonRepository();
            var persons = repository.GetByGender(gender);
            return Ok(persons);
        } 


        [HttpGet]
        [Route("ByMaxAge/{age}")]
        public IActionResult GetByMaxAge(int age)//Aqui creo mi valor que voy a mandar 
        {
            var repository = new PersonRepository();
            var persons = repository.GetByMaxAge(age);//Necesito mandarle un valor para que funcione
            return Ok(persons);
        } 


        [HttpGet]
        [Route("Diferences/{job}")]//Aqui creo mi ruta para acceder a esta consulta
        public IActionResult GetDiferences(string job)
        {
            var repository = new PersonRepository();
            var persons = repository.GetDiferences(job);//Este metodo necesita que le mande un valor
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Jobs")]
        public IActionResult GetJobs()
        {
            var repository = new PersonRepository();
            var persons = repository.GetJobs();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Contains/{partName}")]
        public IActionResult GetContains(string partName)
        {
            var repository = new PersonRepository();
            var persons = repository.GetContains(partName);
            return Ok(persons);
        } 

         [HttpGet]
        [Route("ByAges")]
        public IActionResult GetByAges()
        {
            var repository = new PersonRepository();
            var persons = repository.GetByAges();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("ByRangeAge/{minAge}/{maxAge}")]
        public IActionResult GetByRangeAge(int minAge, int maxAge)
        {
            var repository = new PersonRepository();
            var persons = repository.GetByRangeAge(minAge, maxAge);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("PeopleOrdered/{age}")]
        public IActionResult GetPersonsOrdered(int age)
        {
            var repository = new PersonRepository();
            var persons = repository.GetPersonsOrdered(age);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("PersonOrderedDesc/{job}")]
        public IActionResult GetPersonOrderedDesc(string job)
        {
            var repository = new PersonRepository();
            var persons = repository.GetPersonOrderedDesc(job);
            return Ok(persons);

        } 


        [HttpGet]
        [Route("People1/{age}")]
        public IActionResult CountPeople(int age)
        {
            var repository = new PersonRepository();
            var persons = repository.CountPeople(age);
            return Ok(persons);

        } 


          [HttpGet]
        [Route("Person1/{lastName}")]
        public IActionResult ExistPerson(string lastName)
        {
            var repository = new PersonRepository();
            var persons = repository.ExistPerson(lastName);
            return Ok(persons);

        } 


         [HttpGet]
        [Route("Person2/{job}/{age}")]
        public IActionResult GetPerson(string job, int age)
        {
            var repository = new PersonRepository();
            var persons = repository.GetPerson(job, age);
            return Ok(persons);

        } 

        [HttpGet]
        [Route("People2/{job}/{take}")]
        public IActionResult TakePeople(string job, int take)
        {
            var repository = new PersonRepository();
            var persons = repository.TakePeople(job, take);
            return Ok(persons);

        } 

         [HttpGet]
        [Route("People3/{job}/{skip}")]
        public IActionResult SkipPeople(string job, int skip)
        {
            var repository = new PersonRepository();
            var persons = repository.SkipPeople(job, skip);
            return Ok(persons);

        } 

         [HttpGet]
        [Route("TakePeople/{job}/{skip}/{take}")]
        public IActionResult SkipTakePeople(string job, int skip, int take)
        {
            var repository = new PersonRepository();
            var persons = repository.SkipTakePeople(job, skip, take );
            return Ok(persons);

        } 




    }
}