using Dapper.Contrib.Extensions;

namespace FacApi.Domain.Modulos
{
    [Table("pergunta")]
    public class Pergunta
    {
        [Key]
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
