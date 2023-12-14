using AutoMapper;
using Hotel.Core.DTOs;
using Hotel.Core.Models;
using Hotel.Core.Repositories;
using Hotel.Core.Services;
using Hotel.Core.UnitOfWorks;
using Hotel.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.Services
{
    public class RoomServiceWithDTO : ServiceWithDTO<Room, RoomDTO>, IRoomServiceWithDTO
    {
        //burada Room ayrı servis oluşturduk bu servisin ayrı repository kodları var GenericRepositoryden değil RoomRepositoryden geliyo onu almamız lazım.
        private readonly IRoomRepository _roomRepository;

        public RoomServiceWithDTO(IGenericRepository<Room> repository, IUnitOfWork unitOfWork, IMapper mapper, IRoomRepository roomRepository) : base(repository, unitOfWork, mapper)
        {
            _roomRepository = roomRepository;
        }

        //overload edilmiş aldığı parametre farklı
        public async Task<CustomResponseDTO<RoomDTO>> AddAsync(RoomCreateDTO createDTO)
        {
            var room = _mapper.Map<Room>(createDTO); //clientten gelen dtoyu room çevir
            await _roomRepository.AddAsync(room);   //roomun ekle yani flagı değiştir transaction bitmedi
            await _unitOfWork.CommitAsync();         //transactionu bitir veritabanına kaydet.
            var roomDTO = _mapper.Map<RoomDTO>(room);   //kullanıcıya göstermek için tekrar mapleme yap
            return CustomResponseDTO<RoomDTO>.Success(StatusCodes.Status200OK, roomDTO);   //oluşturduğumuz custom responseDTO dön
        }

        //bu metod genericservisten overload ediliyor
        public async Task<CustomResponseDTO<IEnumerable<RoomDTO>>> AddRangeAsync(IEnumerable<RoomCreateDTO> roomCreateDtoList)
        {
            var roomList = _mapper.Map<List<Room>>(roomCreateDtoList); //clientten gelen dtoyu room çevir
            await _roomRepository.AddRangeAsync(roomList);   //roomun ekle yani flagı değiştir transaction bitmedi
            await _unitOfWork.CommitAsync();         //transactionu bitir veritabanına kaydet.
            var roomDTOList = _mapper.Map<List<RoomDTO>>(roomList);   //kullanıcıya göstermek için tekrar mapleme yap
            return CustomResponseDTO<IEnumerable<RoomDTO>>.Success(StatusCodes.Status200OK, roomDTOList);   //oluşturduğumuz custom responseDTO dön
        }

        public Task<CustomResponseDTO<List<RoomWithFloorDTO>>> GetRoomsWithFloor()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDTO<List<RoomWithFloorDTO>>> GetRoomsWithFloorAsync()
        {
            var roomsWithFloor = await _roomRepository.GetRoomsWithFloorAsync();
            var roomsWithFloorDTO = _mapper.Map<List<RoomWithFloorDTO>>(roomsWithFloor);
            return CustomResponseDTO<List<RoomWithFloorDTO>>.Success(StatusCodes.Status200OK, roomsWithFloorDTO);
        }

        public async Task<CustomResponseDTO<RoomWithCustomersDTO>> GetSingleRoomByIdWithCustomersAsync(int roomId)
        {
            var roomWithCustomer = await _roomRepository.GetSingleRoomByIdWithCustomersAsync(roomId);
            var roomWithCustomersDTO = _mapper.Map<RoomWithCustomersDTO>(roomWithCustomer);
            return CustomResponseDTO<RoomWithCustomersDTO>.Success(StatusCodes.Status200OK, roomWithCustomersDTO);
        }

        //overload metod
        public async Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(RoomUpdateDTO updateDTO)
        {
            var room = _mapper.Map<Room>(updateDTO);
            _roomRepository.Update(room);
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<NoContentDTO>.Success(StatusCodes.Status204NoContent);
        }
    }
}