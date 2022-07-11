using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly UsuariosService usuariosService;
        public UsuariosController()
        {
            usuariosService = new UsuariosService();
        }
        // GET api/Usuarios        
        public IHttpActionResult Get()
        {            
            var usuarios = usuariosService.ListaUsuarios();
            if (usuarios.Count>0)
            {
               return Ok(usuarios);
            }
            else
            {
                return NotFound();
            }            
        }

        // GET api/Usuarios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Usuarios
        public IHttpActionResult Post([FromBody] UsuarioDto usuarioDto)
        {
            bool guardado=usuariosService.GuardarUsuario(usuarioDto);
            if (guardado)
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        // PUT api/Usuarios/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Usuarios/5
        public void Delete(int id)
        {
        }
    }
}
