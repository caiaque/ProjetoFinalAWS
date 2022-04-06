using CampeonatoBrasileiro.Domain.Entities;
using CampeonatoBrasileiro.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add<TValidator>(TEntity objeto) where TValidator : AbstractValidator<TEntity>
        {
            Validate(objeto, Activator.CreateInstance<TValidator>());
            _baseRepository.Add(objeto);
            return objeto;
        }

        private void Validate<TValidator>(object objeto, TValidator validator) where TValidator : AbstractValidator<TEntity>
        {
            if (objeto == null)
                throw new Exception("Dados não encontrados!");

        }

        public void Delete(Guid id)
        {
            _baseRepository.Delete(id);
        }

        public IList<TEntity> GetAll()
        {
            return _baseRepository.GetList();
        }

        public TEntity GetById(Guid id)
        {
            return _baseRepository.Get(id);
        }

        public TEntity Update<TValidator>(TEntity obj, Guid id) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj, id);
            return obj;
        }
    }
}
