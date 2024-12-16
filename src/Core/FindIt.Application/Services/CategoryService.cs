using AutoMapper;
using FindIt.Application.ErrorHandling;
using FindIt.Application.Interfaces;
using FindIt.Application.Specifications.CategorySpecification;
using FindIt.Domain.Interfaces;
using FindIt.Domain.ProductEntities;
using FindIt.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindIt.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<CategoryRequest>> CreateCategoryAsync(CategoryRequest request)
        {
            try
            {
                var repo = _unitOfWork.Repository<Category>();
                var entity = _mapper.Map<Category>(request);
                await repo.AddAsync(entity);
                await _unitOfWork.CompleteAsync();
                return Result.Success(request);
            }
            catch (Exception ex)
            {
                return Result.Failure<CategoryRequest>(new Status(500, "Failed to create category: " + ex.Message));
            }
        }

        public async Task<Result<string>> DeleteCategoryAsync(int id)
        {
            try
            {
                var repo = _unitOfWork.Repository<Category>();
                var entity = await repo.GetByIdAsync(id);

                if (entity == null)
                {
                    return Result.Failure<string>(new Status(404, "Category not found."));
                }

                repo.Delete(entity);
                await _unitOfWork.CompleteAsync();
                return Result.Success("Delete Success");
            }
            catch (Exception ex)
            {
                return Result.Failure<string>(new Status(500, "Failed to delete category: " + ex.Message));
            }
        }

        public async Task<Result<IReadOnlyList<CategoryResponse>>> GetAllCategoriesAsync()
        {
            try
            {
                var repo = _unitOfWork.Repository<Category>();
                var allCategories = await repo.GetAllAsync();
                var responseCategories = _mapper.Map<IReadOnlyList<CategoryResponse>>(allCategories);
                return Result.Success(responseCategories);
            }
            catch (Exception ex)
            {
                return Result.Failure<IReadOnlyList<CategoryResponse>>(new Status(500, ex.Message));
            }
        }

        public async Task<Result<CategoryResponse>> GetCategoryByIdAsync(int id)
        {
            try
            {
                var repo = _unitOfWork.Repository<Category>();
                var entity = await repo.GetByIdAsync(id);

                if (entity == null)
                {
                    return Result.Failure<CategoryResponse>(new Status(404, "Category not found."));
                }

                var response = _mapper.Map<CategoryResponse>(entity);
                return Result.Success(response);
            }
            catch (Exception ex)
            {
                return Result.Failure<CategoryResponse>(new Status(500, ex.Message));
            }
        }

        public async Task<Result<IReadOnlyList<CategoryResponse>>> SearchAsync(string searchQuery)
        {
            try
            {
                var repo = _unitOfWork.Repository<Category>();
                var specification = new CategorySearchSpecification(searchQuery);
                var searchResults = await repo.GetAllBySpecificationAsync(specification);
                var response = _mapper.Map<IReadOnlyList<CategoryResponse>>(searchResults);
                return Result.Success(response);
            }
            catch (Exception ex)
            {
                return Result.Failure<IReadOnlyList<CategoryResponse>>(new Status(500, ex.Message));
            }
        }

        public async Task<Result<CategoryResponse>> UpdateCategoryAsync(int id, CategoryRequest request)
        {
            try
            {
                var repo = _unitOfWork.Repository<Category>();
                var entity = await repo.GetByIdAsync(id);

                if (entity == null)
                {
                    return Result.Failure<CategoryResponse>(new Status(404, "Category not found."));
                }

                _mapper.Map(request, entity);
                repo.Update(entity);
                await _unitOfWork.CompleteAsync();

                var response = _mapper.Map<CategoryResponse>(entity);
                return Result.Success(response);
            }
            catch (Exception ex)
            {
                return Result.Failure<CategoryResponse>(new Status(500, "Failed to update category: " + ex.Message));
            }
        }
    }

   
}
