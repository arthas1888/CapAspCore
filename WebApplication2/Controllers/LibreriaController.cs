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
    [Route("api/Librerias")]
    public class LibreriaController : Controller
    {
        private readonly CRUD<Libreria> _cRepository;
        public LibreriaController(CRUD<Libreria> cRepository)
        {
            _cRepository = cRepository;
        }
        // GET: api/Librerias
        [HttpGet]
        public IEnumerable Get()
        {
            return _cRepository.Read();
        }

        // GET: api/Librerias/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = _cRepository.Retrieve(id);
            return res == null ? (IActionResult)NotFound() : Ok(res);
        }

        // POST: api/Librerias
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Super-Usuario, Administrador")]
        [HttpPost]
        public IActionResult Post([FromBody]Libreria model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_cRepository.Create(model));
        }

        // PUT: api/Librerias/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
            Roles = "Super-Usuario, Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]Libreria model)
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
