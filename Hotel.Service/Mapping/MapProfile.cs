using AutoMapper;
using Hotel.Core.DTOs;
using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Hostel, HostelDTO>().ReverseMap();
            CreateMap<Floor, FloorDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Bed, BedDTO>().ReverseMap();
            CreateMap<Payment, PaymentDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<RoomCreateDTO, Room>(); //post metodda çalışır clientten gelen DTO room maplenir ki database işlemi yapılsın.
            CreateMap<RoomUpdateDTO, Room>();
            CreateMap<Room, RoomWithBedsDTO>(); //get metodda çalışır cliente veritabanından gelen room bilgisini gösteriyorz
            CreateMap<Floor, FloorWithRoomsDTO>(); //get metodda çalışcak bu da sağdaki kısım maplenecek varış noktası en son verinini hali.
            CreateMap<Floor, FloorWithHostelDTO>();
            CreateMap<Customer, CustomerWithPaymentDTO>();
            CreateMap<Hostel, HostelWithFloorsDTO>();
        }
    }
}