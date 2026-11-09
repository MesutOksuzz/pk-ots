using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ots.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[NonController]
public class ReadWriteController : ControllerBase
{
    // GET: api/<ReadWrite>
    [HttpGet("GetAll")]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<ReadWrite>/5
    [HttpGet("GetById/{id}")]
    public string Get([FromRoute]int id)
    {
        return "value";
    }
    // POST api/<ReadWrite>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ReadWrite>/5
    [HttpPut("{id}")]
    public void Put([FromRoute]int id, [FromBody] string value)
    {
    }

    // DELETE api/<ReadWrite>/5
    [HttpDelete("{id}")]
    public void Delete([FromRoute]int id)
    {
    }
}

