using AutoMapper;
using Livraria.Application.Interfaces;
using Livraria.Application.Models;
using Livraria.Application.ViewModels;
using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Application
{
    public class LivrariaApplication : ILivrariaApplication
    {
        private readonly IMapper _mapper;

        private readonly ILivrariaRepository _livrariaRepository;

        public LivrariaApplication(ILivrariaRepository livrariaRepository,
            IMapper mapper)
        {
            _livrariaRepository = livrariaRepository;
            _mapper = mapper;
        }

        public async Task<ResultModel<LivrariaViewModel>> GetLivroByIdAsync(int id)
        {
            ResultModel<LivrariaViewModel> result = new ResultModel<LivrariaViewModel>();
            try
            {
                LivrariaModel model = await _livrariaRepository.GetLivroByIdAsync(id)
                    .ConfigureAwait(false);
                if (model != null)
                    result.Resultado = _mapper.Map<LivrariaViewModel>(model);
            }
            catch (Exception ex)
            {
                result.Inconsistencias.Add(ex.Message);
            }

            return result;
        }

        public async Task<ResultModel<LivrariaViewModel>> GetLivroByTituloAsync(string titulo)
        {
            ResultModel<LivrariaViewModel> result = new ResultModel<LivrariaViewModel>();
            try
            {
                LivrariaModel model = await _livrariaRepository.GetLivroByTituloAsync(titulo)
                    .ConfigureAwait(false);
                if (model != null)
                    result.Resultado = _mapper.Map<LivrariaViewModel>(model);
            }
            catch (Exception ex)
            {
                result.Inconsistencias.Add(ex.Message);
            }

            return result;
        }

        public async Task<ResultModel<IList<LivrariaViewModel>>> GetLivrosAsync()
        {
            ResultModel<IList<LivrariaViewModel>> result = new ResultModel<IList<LivrariaViewModel>>();
            try
            {
                IList<LivrariaModel> list = await _livrariaRepository.GetLivrosAsync()
                    .ConfigureAwait(false);
                if (list.Any())
                    result.Resultado = _mapper.Map<IList<LivrariaViewModel>>(list);
            }
            catch (Exception ex)
            {
                result.Inconsistencias.Add(ex.Message);
            }

            return result;
        }

        public async Task<ResultModel<IList<LivrariaViewModel>>> GetLivrosByAutorAsync(string autor)
        {
            ResultModel<IList<LivrariaViewModel>> result = new ResultModel<IList<LivrariaViewModel>>();
            try
            {
                IList<LivrariaModel> list = await _livrariaRepository.GetLivrosByAutorAsync(autor)
                    .ConfigureAwait(false);
                if (list.Any())
                    result.Resultado = _mapper.Map<IList<LivrariaViewModel>>(list);
            }
            catch (Exception ex)
            {
                result.Inconsistencias.Add(ex.Message);
            }

            return result;
        }

        public async Task<ResultModel<LivrariaViewModel>> SaveAsync(LivrariaViewModel model)
        {
            ResultModel<LivrariaViewModel> result = new ResultModel<LivrariaViewModel>();
            try
            {
                LivrariaModel modelResult = _mapper.Map<LivrariaModel>(model);
                LivrariaModel dataResult = await _livrariaRepository.SaveAsync(modelResult)
                    .ConfigureAwait(false);
                if (dataResult != null)
                    result.Resultado = _mapper.Map<LivrariaViewModel>(dataResult);
            }
            catch (Exception ex)
            {
                result.Inconsistencias.Add(ex.Message);
            }

            return result;
        }

        public async Task<ResultModel<LivrariaViewModel>> EditAsync(LivrariaViewModel model)
        {
            ResultModel<LivrariaViewModel> result = new ResultModel<LivrariaViewModel>();
            try
            {
                LivrariaModel modelResult = _mapper.Map<LivrariaModel>(model);
                LivrariaModel dataResult = await _livrariaRepository.EditAsync(modelResult)
                    .ConfigureAwait(false);
                if (dataResult != null)
                    result.Resultado = _mapper.Map<LivrariaViewModel>(dataResult);
            }
            catch (Exception ex)
            {
                result.Inconsistencias.Add(ex.Message);
            }

            return result;
        }

        public async Task<ResultModel<object>> DeleteAsync(int id)
        {
            ResultModel<object> result = new ResultModel<object>();
            try
            {
                result.Resultado = await _livrariaRepository.DeleteAsync(id)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                result.Inconsistencias.Add(ex.Message);
            }

            return result;
        }
    }
}
