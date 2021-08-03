using FacApi.Domain.Modulos;
using FacApi.Infra.Repositorio;
using FacApi.Service.Negocios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace FacApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntaController : Controller
    {
        private readonly ILogger<PerguntaController> _logger;
        private readonly PerguntaServico _perguntaServico;

        public PerguntaController(ILogger<PerguntaController> logger, IRepositorioBase repositorioBase)
        {
            _logger = logger;
            _perguntaServico = new PerguntaServico(repositorioBase);
        }
        
        [HttpGet]
        public List<Pergunta> ObterPerguntas(int pagina)
        {
            try
            {
                return _perguntaServico.BuscarTodasPerguntas(pagina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public long InserirPergunta(Pergunta pergunta)
        {
            try
            {
                return _perguntaServico.InserirPergunta(pergunta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public bool DeletarPergunta(Pergunta pergunta)
        {
            try
            {
                return _perguntaServico.Deletar(pergunta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
           
    }
}
