﻿using API.Models;
using API.Repositorios;
using API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{   
    //api/{nomeDaController
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioReposity _usuarioReposity;

        public UsuarioController(IUsuarioReposity usuarioReposity) 
        {
            _usuarioReposity = usuarioReposity;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsers()
        {   

            List<UsuarioModel> usuarios = await _usuarioReposity.SerchAllUser();
            
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> SerchUserById(int id)
        {

            UsuarioModel usuario = await _usuarioReposity.SerchUserById(id);

            
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> AddUser([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioReposity.AddUser(usuarioModel);

            return Ok(usuario);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<UsuarioModel>> UpdateUser([FromBody] UsuarioModel usuarioModel, int id)
        {   

            usuarioModel.Id = id;

            UsuarioModel usuario = await _usuarioReposity.UpdateUser(usuarioModel, id);

;            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> RemoveUser(int id)
        {

            bool delete = await _usuarioReposity.RemoveUser(id);

            return Ok(delete);
        }
    }
}
 