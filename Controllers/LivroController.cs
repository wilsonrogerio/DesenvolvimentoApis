using Chapter_TURMA14.Models;
using Chapter_TURMA14.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Chapter_TURMA14.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository? _livroRepository;

        public LivroController(LivroRepository? livroRepository)
        {
            _livroRepository = livroRepository;
        }
        [HttpGet]

        public IActionResult listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro livrobuscado = _livroRepository.BuscarPorId(id);
                if (livrobuscado == null)
                {
                    return NotFound();
                }

                return Ok(livrobuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [Authorize(Roles ="1")]
        [HttpPost]
        public IActionResult Cadastrar(Livro l)
        {
            try
            {
                _livroRepository.Cadastrar(l);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);
                return Ok("Livro Removido com sucesso");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Livro l)
        {
            try
            {
                _livroRepository.Alterar(id, l);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception (e.Message);
            }

        }
    }
}
