using Marten;
using Microsoft.AspNetCore.Mvc;

namespace MyDockerApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IDocumentStore _store;

    // Constructor injection of Marten's document store
    public PersonController(IDocumentStore store)
    {
        _store = store;
    }

    // GET: api/person/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerson(Guid id)
    {
        using var session = _store.LightweightSession();

        var person = await session.LoadAsync<Person>(id);

        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    // POST: api/person
    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] Person person)
    {
        if (person == null)
        {
            return BadRequest();
        }

        using var session = _store.LightweightSession();
               

        session.Store(person);
        await session.SaveChangesAsync();  // Persist to the database

        return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
    }

    // DELETE: api/person/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(Guid id)
    {
        using var session = _store.LightweightSession();

        var person = await session.LoadAsync<Person>(id);

        if (person == null)
        {
            return NotFound();
        }

        session.Delete(person);
        await session.SaveChangesAsync();  // Commit the deletion to the database

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPersons()
    {
        using var session = _store.LightweightSession();

        var persons = await session.Query<Person>()
                                   .ToListAsync();

        return Ok(persons);
    }

}

 
public record Person(Guid Id, string Name, int Age);
