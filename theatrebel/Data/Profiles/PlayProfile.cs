using AutoMapper;
using theatrebel.Data.DTOs;
using theatrebel.Data.Models;
using theatrebel.Data.Views;
using theatrebel.Repositories.Interfaces;

namespace theatrebel.Data.Profiles
{
    public class PlayProfile : Profile
    {
        public PlayProfile()
        {
            CreateMap<PlayDTO, Play>()
                .AfterMap<MapWritersAction>();

            CreateMap<Play, PlayView>();
            CreateMap<Play, EmbeddedPlayView>();
        }
    }

    public class MapWritersAction : IMappingAction<PlayDTO, Play>
    {
        private readonly IWriterRepository _writerRepository;

        public MapWritersAction(IWriterRepository writerRepository)
        {
            _writerRepository = writerRepository;
        }

        public void Process(PlayDTO source, Play destination, ResolutionContext context)
        {
            destination.Writers = _writerRepository.FindAllById(source.WriterIds);
        }
    }
}
