using System.Collections.Generic;

namespace Livraria.Application.Models
{
    public class ResultModel<TEntity> where TEntity : class
    {
        public TEntity Resultado { get; set; }
        public bool Sucesso { get; }
        public IList<string> Inconsistencias { get; set; }
    }
}
