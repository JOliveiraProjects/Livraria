using Livraria.Domain.Interfaces;
using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Infra.Data.Repository
{
    public class LivrariaRepository : ILivrariaRepository, IDisposable
    {
        private readonly DataBaseContext _context;

        public LivrariaRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<LivrariaModel> GetLivroByIdAsync(int id)
        {
            try
            {
                return await _context.Livros.FirstOrDefaultAsync(x => x.Id == id)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao retornar o usuário! {ex.Message}");
            }
        }

        public async Task<IList<LivrariaModel>> GetLivrosAsync()
        {
            try
            {
                return await _context.Livros.Where(x => x.Status == true)
                    .ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao retornar o usuário! {ex.Message}");
            }
        }

        public async Task<LivrariaModel> GetLivroByTituloAsync(string titulo)
        {
            try
            {
                return await _context.Livros
                    .FirstOrDefaultAsync(x => x.Titulo.Contains(titulo))
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao retornar o usuário! {ex.Message}");
            }
        }

        public async Task<IList<LivrariaModel>> GetLivrosByAutorAsync(string autor)
        {
            try
            {
                return await _context.Livros.Where(x => x.Autor.Contains(autor))
                    .ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao retornar o usuário! {ex.Message}");
            }
        }

        public async Task<LivrariaModel> SaveAsync(LivrariaModel model)
        {
            try
            {
                LivrariaModel modelResult = await _context.Livros
                    .FirstOrDefaultAsync(x => x.Titulo.Equals(model.Titulo))
                    .ConfigureAwait(false);

                if(modelResult == null)
                {
                    model.Status = true;
                    await _context.Livros.AddAsync(model);
                    _context.SaveChanges();
                    return model;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao retornar o usuário! {ex.Message}");
            }
        }

        public async Task<LivrariaModel> EditAsync(LivrariaModel model)
        {
            try
            {
                LivrariaModel resultModel = await _context.Livros
                    .FirstOrDefaultAsync(x => x.Id == model.Id)
                    .ConfigureAwait(false);

                if (resultModel != null)
                {
                    resultModel.Titulo = model.Titulo;
                    resultModel.Autor = model.Autor;
                    _context.Entry(resultModel).State = EntityState.Modified;
                    _context.SaveChanges();  
                }

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao retornar o usuário! {ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                LivrariaModel resultModel = await _context.Livros
                    .FirstOrDefaultAsync(x => x.Id == id)
                    .ConfigureAwait(false);

                if (resultModel != null)
                {
                    _context.Livros.Remove(resultModel);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao retornar o usuário! {ex.Message}");
            }
        }
    }
}
