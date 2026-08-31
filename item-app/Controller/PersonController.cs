using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using ItemApp.Models;

namespace ItemApp.Controllers
{
    

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{

    private static List<Person> persons = new List<Person>()
    {
        new Person() 
        {
            Id = 1, 
            Name = "John Doe"
        },
        new Person() 
        {
            Id = 2, 
            Name = "Jeremy Doe"
        },
    };

    [HttpGet("Items")]
    public List<Person> Items()
    {    
        return persons;
    }
    
    [HttpPost("AddItem")]
    public IActionResult AddItem([FromBody]string name)
    {

        foreach (var item in persons)
        {
            if(item.Name == name)
            {
                return BadRequest("Name exist");
                break;        
            }
        }

        Person person = new Person();
        person.Id = persons.Count() + 1;
        person.Name = name;
        persons.Add(person);

        return Ok("Success");
    }


}

}