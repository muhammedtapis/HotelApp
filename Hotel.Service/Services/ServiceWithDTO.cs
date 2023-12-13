using AutoMapper;
using Hotel.Core.DTOs;
using Hotel.Core.Models;
using Hotel.Core.Repositories;
using Hotel.Core.Services;
using Hotel.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.Services
{
    public class ServiceWithDTO<Entity, DTO> : IServiceWithDTO<Entity, DTO> where Entity : BaseEntity where DTO : class
    {
        //bu serviste ihtiyacımız olanlar repository veritabanı işlemleri yapıyor lazım bize

        private readonly IGenericRepository<Entity> _repository;

        //services klasründeki özel servisler CAtegoryService gibi bu ServiceWithDTO servisine ek CategoryServiceWithDTO gibi
        //ek servisler yazarsak bu servisten kalıtım alacaklar o sebeple unitOfWork erişmek için protected yaptık.
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;

        public ServiceWithDTO(IGenericRepository<Entity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<DTO>> AddAsync(DTO dto)
        {
            Entity entity = _mapper.Map<Entity>(dto); //parantez içinde dto yu entity maple
            await _repository.AddAsync(entity);  //bu entitiy repository metoduyla flagını added yap
            await _unitOfWork.CommitAsync(); //flag added olduktan sonra database yansıt
            var newDTO = _mapper.Map<DTO>(entity); //kullanıcıya göstermek için tekrar dto çevir
            return CustomResponseDTO<DTO>.Success(StatusCodes.Status200OK, newDTO); //oluşturduğumuz custom response dön
        }

        public async Task<CustomResponseDTO<IEnumerable<DTO>>> AddRangeAsync(IEnumerable<DTO> dtoList)
        {
            IEnumerable<Entity> entityList = _mapper.Map<List<Entity>>(dtoList); //parantez içinde dto yu entityliste maple
            await _repository.AddRangeAsync(entityList);  //bu entitiy repository metoduyla flagını added yap
            await _unitOfWork.CommitAsync(); //flag added olduktan sonra database yansıt
            var newDTO = _mapper.Map<IEnumerable<DTO>>(entityList); //kullanıcıya göstermek için tekrar dto çevir
            return CustomResponseDTO<IEnumerable<DTO>>.Success(StatusCodes.Status200OK, newDTO); //oluşturduğumuz custom response dön
        }

        public async Task<CustomResponseDTO<bool>> AnyAsync(Expression<Func<Entity, bool>> expression)
        {
            var isAny = await _repository.AnyAsync(expression);
            return CustomResponseDTO<bool>.Success(StatusCodes.Status200OK, isAny);
        }

        public async Task<CustomResponseDTO<IEnumerable<DTO>>> GetAllAsync()
        {
            IEnumerable<Entity> entities = await _repository.GetAll().ToListAsync();
            var newDtoList = _mapper.Map<IEnumerable<DTO>>(entities); //neye mapleniyor Ienumerable DTO ya
            return CustomResponseDTO<IEnumerable<DTO>>.Success(StatusCodes.Status200OK, newDtoList);
        }

        public async Task<CustomResponseDTO<DTO>> GetByIdAsync(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            var entityDTO = _mapper.Map<DTO>(entity);
            return CustomResponseDTO<DTO>.Success(StatusCodes.Status200OK, entityDTO);
        }

        public async Task<CustomResponseDTO<NoContentDTO>> RemoveAsync(int id)
        {
            Entity entity = await _repository.GetByIdAsync(id);
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<NoContentDTO>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDTO<NoContentDTO>> RemoveRangeAsync(IEnumerable<int> idList)
        {
            IEnumerable<Entity> entities = await _repository.Where(x => idList.Contains(x.Id)).ToListAsync(); //listenin içinde o idler varsa onları dbden al
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<NoContentDTO>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(DTO dto)
        {
            Entity entity = _mapper.Map<Entity>(dto);
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<NoContentDTO>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<CustomResponseDTO<IEnumerable<DTO>>> Where(Expression<Func<Entity, bool>> expression)
        {
            var entities = await _repository.Where(expression).ToListAsync();
            var entitiesDTO = _mapper.Map<IEnumerable<DTO>>(entities);
            return CustomResponseDTO<IEnumerable<DTO>>.Success(StatusCodes.Status200OK, entitiesDTO);
        }
    }
}