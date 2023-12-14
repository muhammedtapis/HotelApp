using AutoMapper;
using Hotel.Core.DTOs;
using Hotel.Core.Models;
using Hotel.Core.Repositories;
using Hotel.Core.Services;
using Hotel.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.Services
{
    public class FloorServiceWithDTO : ServiceWithDTO<Floor, FloorDTO>, IFloorServiceWithDTO
    {
        //repository ekle !!
        private readonly IFloorRepository _floorRepository;

        public FloorServiceWithDTO(IGenericRepository<Floor> repository, IUnitOfWork unitOfWork, IMapper mapper, IFloorRepository floorRepository) : base(repository, unitOfWork, mapper)
        {
            _floorRepository = floorRepository;
        }

        public async Task<CustomResponseDTO<IEnumerable<FloorWithHostelDTO>>> GetFloorsWithHostelAsync()
        {
            var floors = await _floorRepository.GetFloorsWithHostelAsync();
            var floorsWithHostelDto = _mapper.Map<IEnumerable<FloorWithHostelDTO>>(floors);
            return CustomResponseDTO<IEnumerable<FloorWithHostelDTO>>.Success(StatusCodes.Status200OK, floorsWithHostelDto);
        }

        public async Task<CustomResponseDTO<FloorWithRoomsDTO>> GetSingleFloorByIdWithRoomsAsync(int floorId)
        {
            var floor = await _floorRepository.GetSingleFloorByIdWithRoomsAsync(floorId);
            var floorWithRooms = _mapper.Map<FloorWithRoomsDTO>(floor);
            return CustomResponseDTO<FloorWithRoomsDTO>.Success(StatusCodes.Status200OK, floorWithRooms);
        }
    }
}