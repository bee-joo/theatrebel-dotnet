using AutoMapper;
using theatrebel.Data.DTOs;
using theatrebel.Data.Models;
using theatrebel.Data.Views;

namespace theatrebel.Data.Profiles
{
    public class WriterProfile : Profile
    {
        public WriterProfile()
        {
            CreateMap<WriterDTO, Writer>();
            CreateMap<Writer, WriterView>();
            CreateMap<Writer, EmbeddedWriterView>();
        }
    }
}
