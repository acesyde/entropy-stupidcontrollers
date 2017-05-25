namespace Framework.StupidControllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    [Route("api/[controller]")]
    [GenericControllerConvention]
    public class GenericController<T, TIdentitifier> : Controller where T : IBaseEntity<TIdentitifier>
    {
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get()
        {
            return Ok($"Hello from {GetType().FullName}.");
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetById(TIdentitifier id)
        {
            return Ok($"Get {id.ToString()}");
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Create([FromBody] T data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreatedAtAction("Get", new { id = data.Id }, data);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Put(TIdentitifier id, [FromBody] T data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(data);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(TIdentitifier id)
        {
            return Ok();
        }
    }
}
