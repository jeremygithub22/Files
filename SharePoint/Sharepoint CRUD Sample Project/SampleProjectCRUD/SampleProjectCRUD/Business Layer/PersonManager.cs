using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleProjectCRUD.Models;
using SampleProjectCRUD.Data_Access_Layer;
namespace SampleProjectCRUD.Business_Layer
{
    public class PersonManager
    {
        PersonService personService = new PersonService();

        public void addPerson(Person person)
        {
            personService.addPerson(person);
        }

        public void updatePerson(Person person)
        {
            personService.updatePerson(person);
        }
        public void deletePerson(int id)
        {
            personService.deletePerson(id);
        }
        public Person retrievePerson(int id)
        {
            return personService.retrievePerson(id);
        }

        public List<Person> retrievePerson()
        {
            return personService.retrievePerson();
        }
    }
}
