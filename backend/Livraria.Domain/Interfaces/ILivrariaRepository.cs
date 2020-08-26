using Livraria.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Domain.Interfaces
{
    public interface ILivrariaRepository
    {
        Task<LivrariaModel> GetLivroByIdAsync(int id);

        Task<IList<LivrariaModel>> GetLivrosAsync();

        Task<LivrariaModel> GetLivroByTituloAsync(string titulo);

        Task<IList<LivrariaModel>> GetLivrosByAutorAsync(string autor);

        Task<LivrariaModel> SaveAsync(LivrariaModel model);

        Task<LivrariaModel> EditAsync(LivrariaModel model);

        Task<bool> DeleteAsync(int id);
    }
}
