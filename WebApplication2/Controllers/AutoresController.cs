using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;
using WebApplication2.Models;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApplication1.models;

namespace WebApplication2.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/Autores")]
    public class AutoresController : Controller
    {
        private readonly CRUD<Autor> _cRepository;
        public AutoresController(CRUD<Autor> cRepository)
        {
            _cRepository = cRepository;
        }
        // GET: api/Autores
        [HttpGet]
        public IEnumerable Get()
        {
            //var list = ((AutorManager) _cRepository).ReadNames();
            return _cRepository.Read();
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var res = _cRepository.Retrieve(id);
            return res == null ? (IActionResult)NotFound() : Ok(res);
        }

        // POST: api/Autores
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Super-Usuario, Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody]Autor model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_cRepository.Create(model));
        }

        // PUT: api/Autores/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Super-Usuario, Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Autor model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return _cRepository.Update(id, model) == null ? (IActionResult)NotFound() : Ok(model);
        }

        // DELETE: api/Autores/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Super-Usuario, Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return _cRepository.Delete(id) == null ? (IActionResult)NotFound() : Ok();
        }
    }
}
