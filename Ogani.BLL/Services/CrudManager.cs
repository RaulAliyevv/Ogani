﻿using AutoMapper;
using Ogani.BLL.Services.Contracts;
using Ogani.BLL.ViewModels;
using Ogani.DAL.DataContext.Entities;
using Ogani.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogani.BLL.Services
{
    public class CrudManager<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel> : ICrudService<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel>
    where TEntity : BaseEntity
    where TViewModel : IViewModel
    where TCreateViewModel : IViewModel
    where TUpdateViewModel : IViewModel
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public CrudManager(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TViewModel> CreateAsync(TCreateViewModel createViewModel)
        {
            var entity = _mapper.Map<TEntity>(createViewModel);
            var result = await _repository.CreateAsync(entity);
            var createdEntityViewModel = _mapper.Map<TViewModel>(result);

            return createdEntityViewModel;
        }

        public virtual async Task<TViewModel> DeleteAsync(int id)
        {
            var deletedEntity = await _repository.GetAsync(id);
            if (deletedEntity == null) throw new Exception("Not Found");
            deletedEntity = await _repository.DeleteAsync(deletedEntity);
            var deletedEntityViewModel = _mapper.Map<TViewModel>(deletedEntity);

            return deletedEntityViewModel;
        }

        public virtual Task<List<TViewModel>> GetAllAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TViewModel?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TViewModel?> GetAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TViewModel> UpdateAsync(TUpdateViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}