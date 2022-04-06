using CampeonatoBrasileiro.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoBrasileiro.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidator>(TEntity objeto)
            where TValidator : AbstractValidator<TEntity>;

        void Delete(Guid id);

        IList<TEntity> GetAll();

        TEntity GetById(Guid id);

        TEntity Update<TValidator>(TEntity obj, Guid id) where TValidator : AbstractValidator<TEntity>;
    }
}
