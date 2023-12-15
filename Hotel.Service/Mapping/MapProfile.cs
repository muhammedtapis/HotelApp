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
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            //bu maplemenin amacı update sayfasında id seçince kişinin bilgileri viewdaki alanlara yani CustomerUpdateDTO yüklencek
            //daha sonra Update api endpointi çağırıldığında o view alanlarındaki bilgiler CustomerUpdateDTO olarak alınıp kullanılcak
            //yani text view vs. alanları GetById(); metoduyla önce doldurcaz ondan sonra ordaki alanları değiştirdikten sonra CustomerUpdateDTO olarak alcaz.
            CreateMap<CustomerDTO, CustomerUpdateDTO>();

            CreateMap<RoomCreateDTO, Room>(); //post metodda çalışır clientten gelen DTO room maplenir ki database işlemi yapılsın.
            CreateMap<RoomUpdateDTO, Room>();
            CreateMap<RoomDTO, RoomUpdateDTO>(); //aynı şekilde yukarıdaki customerupdate gibi listeleme ve update çevirisi.

            CreateMap<Room, RoomWithBedsDTO>(); //get metodda çalışır cliente veritabanından gelen room bilgisini gösteriyorz
            CreateMap<Room, RoomWithCustomersDTO>();

            CreateMap<Floor, FloorWithRoomsDTO>(); //get metodda çalışcak bu da sağdaki kısım maplenecek varış noktası en son verinini hali.
            CreateMap<Floor, FloorWithHostelDTO>();

            //CreateMap<Customer, CustomerWithPaymentDTO>()
            //.ForMember(dest => dest.PaymentDto, opt => opt.MapFrom(src => src.Payment)); // eğer DTO sınıfında özel isim verirsen burada o
            //propertyi özel olarak maplemen lazım !!! yoksa mapleme yapamaz ben PaymentDto ismi verirsem IMapper bunu anlamıyor, böyle belirtmem
            //gerekiyor ona
            CreateMap<Customer, CustomerWithRoomDTO>();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<Hostel, HostelWithFloorsDTO>();
        }
    }
}