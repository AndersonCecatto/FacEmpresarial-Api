using FacApi.Domain.Modulos;
using FacApi.Infra.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace FacApi.Service.Negocios
{
    public class PerguntaServico
    {
        private readonly IRepositorioBase _repositorio;

        public PerguntaServico(IRepositorioBase repositorioBase) => _repositorio = repositorioBase;

        public List<Pergunta> BuscarTodasPerguntas(int pagina)
        {
            return _repositorio.BuscarTodos<Pergunta>($"SELECT * FROM pergunta LIMIT 10 OFFSET({pagina} - 1) * 10").ToList();
        }

        public int InserirPergunta(Pergunta pergunta)
            => _repositorio.Inserir(pergunta);

        public bool Deletar(Pergunta pergunta)
            => _repositorio.Deletar(pergunta);

    }
}
