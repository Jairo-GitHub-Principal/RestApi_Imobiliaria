using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI_ImobiliariaSantos.Models;

namespace WebAPI_ImobiliariaSantos.Controllers
{
    [ApiController]
    [Route("/WebAPI_ImobiliariaSantos/api/[controller]")]
    public class LocatariosController : ControllerBase
    {


        public IActionResult Cadastra(Locatarios locatarios)
        {
            if (!ModelState.IsValid) // faz validação no parametro recebido, nesse  caso, ele faz validação em "Imoveis imoveis"
                return BadRequest(ModelState);

            LocatarioServices lc = new LocatarioServices();
            lc.CadastrarLocatario(locatarios);
            return Ok(locatarios);

        }

        [HttpGet]

        public IActionResult ListarTodos()
        {
            try
            {
                LocatarioServices Ls = new LocatarioServices();
                List<Locatarios> locatarios = Ls.ListarLocatarios();
                return Ok(locatarios);
            }
            catch (Exception)
            {
                return StatusCode(500, "Falha ao processar dados");
            }
        }


    }
}