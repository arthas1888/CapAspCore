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
    [Route("api/Libros")]
    public class LibrosController : Controller
    {
        private readonly CRUD<Libro> _cRepository;
        public LibrosController(CRUD<Libro> cRepository)
        {
            _cRepository = cRepository;
        }
        // GET: api/Libros
        [HttpGet]
        public IEnumerable Get()
        {
            return _cRepository.Read();
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = _cRepository.Retrieve(id);
            return res == null ? (IActionResult)NotFound() : Ok(res);
        }

        // POST: api/Libros
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Super-Usuario, Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody]Libro model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_cRepository.Create(model));
        }

        // PUT: api/Libros/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Super-Usuario, Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Libro model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return _cRepository.Update(id, model) == null ? (IActionResult)NotFound() : Ok(model);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Super-Usuario, Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return _cRepository.Delete(id) == null ? (IActionResult)NotFound() : Ok();
        }
    }
}
