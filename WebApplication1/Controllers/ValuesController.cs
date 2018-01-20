using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        List<String> values;
        PersonBO _repo;

        public PersonController(PersonBO repo)
        {
            values = new List<string>();
            values.Add("value 1");
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _repo.Read();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _repo.Retrieve(id);
            return entity == null ? (IActionResult)NotFound() : Ok(entity);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Person model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_repo.Create(model));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Person model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_repo.Update(id, model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_repo.Delete(id));
        }
    }
}
