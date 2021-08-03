using System;
using System.Collections.Generic;

namespace FacApi.Infra.Repositorio
{
    public interface IRepositorioBase : IDisposable
    {
        IEnumerable<T> BuscarTodos<T>(string query);
        int Inserir<T>(T entidade) where T : class;
        bool Deletar<T>(T entidade) where T : class;
    }
}
