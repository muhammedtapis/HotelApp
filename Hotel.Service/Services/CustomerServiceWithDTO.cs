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
    public class CustomerServiceWithDTO : ServiceWithDTO<Customer, CustomerDTO>, ICustomerServiceWithDTO
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRoomRepository _roomRepository; //odayla ilgili işlemler var o yüzden aldık

        public CustomerServiceWithDTO(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository, IRoomRepository roomRepository) : base(repository, unitOfWork, mapper)
        {
            _customerRepository = customerRepository;
            _roomRepository = roomRepository;
        }

        //bu metodda bi saçmalık var bak bir ara
        public async Task<CustomResponseDTO<decimal>> GetCustomerWithPriceAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            var price = await CalculateAmountAsync(customer);
            return CustomResponseDTO<decimal>.Success(StatusCodes.Status200OK, price);
        }

        public async Task<CustomResponseDTO<IEnumerable<CustomerWithRoomDTO>>> GetCustomersWithRoomAsync()
        {
            var customers = await _customerRepository.GetCustomersWithRoomAsync();
            var customersWithRoomDto = _mapper.Map<IEnumerable<CustomerWithRoomDTO>>(customers);
            return CustomResponseDTO<IEnumerable<CustomerWithRoomDTO>>.Success(StatusCodes.Status200OK, customersWithRoomDto);
        }

        //kullanıcıdan gelen odaId bilgisine göre odayı bulup oda fiyatını çektik.
        public async Task<decimal> CalculateAmountAsync(Customer customer)
        {
            var room = await _roomRepository.GetByIdAsync(customer.RoomId);
            TimeSpan difference = customer.CheckOutDate - customer.CheckInDate;
            return room.Price * difference.Days;
        }

        public async Task<CustomResponseDTO<CustomerDTO>> AddAsync(CustomerCreateDTO createDTO)
        {
            var customer = _mapper.Map<Customer>(createDTO);
            customer.Payment = await CalculateAmountAsync(customer);
            await _customerRepository.AddAsync(customer);
            await _unitOfWork.CommitAsync();
            var customerDto = _mapper.Map<CustomerDTO>(customer);
            return CustomResponseDTO<CustomerDTO>.Success(StatusCodes.Status200OK, customerDto);
        }

        public async Task<CustomResponseDTO<CustomerDTO>> UpdateAsync(CustomerUpdateDTO updateDTO)
        {
            var customer = _mapper.Map<Customer>(updateDTO);
            customer.Payment = await CalculateAmountAsync(customer);
            _customerRepository.Update(customer);
            await _unitOfWork.CommitAsync();
            var newCustomerDto = _mapper.Map<CustomerDTO>(customer);
            return CustomResponseDTO<CustomerDTO>.Success(StatusCodes.Status200OK, newCustomerDto);
        }
    }
}