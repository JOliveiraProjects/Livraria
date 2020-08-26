using Livraria.Application.Models;
using Livraria.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Livraria.Application.Interfaces
{
    public interface ILivrariaApplication
    {
        Task<ResultModel<LivrariaViewModel>> GetLivroByIdAsync(int id);

        Task<ResultModel<IList<LivrariaViewModel>>> GetLivrosAsync();

        Task<ResultModel<LivrariaViewModel>> GetLivroByTituloAsync(string titulo);

        Task<ResultModel<IList<LivrariaViewModel>>> GetLivrosByAutorAsync(string autor);

        Task<ResultModel<LivrariaViewModel>> SaveAsync(LivrariaViewModel model);

        Task<ResultModel<LivrariaViewModel>> EditAsync(LivrariaViewModel model);

        Task<ResultModel<object>> DeleteAsync(int id);
    }
}
