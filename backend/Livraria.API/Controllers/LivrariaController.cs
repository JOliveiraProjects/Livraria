using Livraria.Application.Interfaces;
using Livraria.Application.Models;
using Livraria.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly ILivrariaApplication _dashApplication;

        public LivrariaController(ILivrariaApplication dashApplication)
        {
            _dashApplication = dashApplication;
        }

        /// <summary>
        /// Busca livro por código.
        /// </summary>
        /// <param name="id">código do livro</param>
        /// <returns></returns>
        [HttpGet("livro/{id}")]
        [ProducesResponseType(typeof(ResultModel<LivrariaViewModel>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultModel<LivrariaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLivroByIdAsync(int id)
        {
            ResultModel<LivrariaViewModel> result = await _dashApplication
                .GetLivroByIdAsync(id).ConfigureAwait(false);

            if (result.Inconsistencias.Any())
                BadRequest(result);

            return Ok(result);
        }


        /// <summary>
        /// Busca livro por titulo.
        /// </summary>
        /// <param name="titulo">titulo do livro</param>
        /// <returns></returns>
        [HttpGet("livro/{titulo}/titulo")]
        [ProducesResponseType(typeof(ResultModel<LivrariaViewModel>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultModel<LivrariaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLivroByTituloAsync(string titulo)
        {
            ResultModel<LivrariaViewModel> result = await _dashApplication
                .GetLivroByTituloAsync(titulo).ConfigureAwait(false);

            if (result.Inconsistencias.Any())
                BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Busca livro por autor.
        /// </summary>
        /// <param name="autor">nome do autor</param>
        /// <returns></returns>
        [HttpGet("livro/{autor}/autor")]
        [ProducesResponseType(typeof(ResultModel<LivrariaViewModel>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultModel<LivrariaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLivrosByAutorAsync(string autor)
        {
            ResultModel<IList<LivrariaViewModel>> result = await _dashApplication
                .GetLivrosByAutorAsync(autor).ConfigureAwait(false);

            if (result.Inconsistencias.Any())
                BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Inserir um livro.
        /// </summary>
        /// <param name="model">objeto do livro</param>
        /// <returns></returns>
        [HttpPost("livro/save")]
        [ProducesResponseType(typeof(ResultModel<LivrariaViewModel>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultModel<LivrariaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SaveAsync(LivrariaViewModel model)
        {
            ResultModel<LivrariaViewModel> result = await _dashApplication
                .SaveAsync(model).ConfigureAwait(false);

            if (result.Inconsistencias.Any())
                BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Edita o livro.
        /// </summary>
        /// <param name="model">objeto do livro</param>
        /// <returns></returns>
        [HttpPut("livro/edit")]
        [ProducesResponseType(typeof(ResultModel<LivrariaViewModel>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultModel<LivrariaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditAsync(LivrariaViewModel model)
        {
            ResultModel<LivrariaViewModel> result = await _dashApplication
                .EditAsync(model).ConfigureAwait(false);

            if (result.Inconsistencias.Any())
                BadRequest(result);

            return Ok(result);
        }

        /// <summary>
        /// Deleta o livro.
        /// </summary>
        /// <param name="id">código do livro</param>
        /// <returns></returns>
        [HttpDelete("livro/delete")]
        [ProducesResponseType(typeof(ResultModel<object>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultModel<object>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            ResultModel<object> result = await _dashApplication
                .DeleteAsync(id).ConfigureAwait(false);

            if (result.Inconsistencias.Any())
                BadRequest(result);

            return Ok(result);
        }
    }
}
