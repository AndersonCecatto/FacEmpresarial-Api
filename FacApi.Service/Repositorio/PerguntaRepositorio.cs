using FacApi.Domain.Modulos;
using FacApi.Infra.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace FacApi.Service
{
    public class PerguntaRepositorio
    {
        private readonly IRepositorioBase _repositorio;

        public PerguntaRepositorio(IRepositorioBase repositorioBase) => _repositorio = repositorioBase;
        
    }
}
