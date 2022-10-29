using AutoMapper;
using theatrebel.Data.DTOs;
using theatrebel.Data.Models;
using theatrebel.Data.Views;
using theatrebel.Exceptions;
using theatrebel.Repositories.Interfaces;
using theatrebel.Services.Interfaces;

namespace theatrebel.Services
{
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _writerRepository;
        private readonly IMapper _mapper;

        public WriterService(IWriterRepository writerRepository, IMapper mapper)
        {
            _writerRepository = writerRepository;
            _mapper = mapper;
        }

        public async Task<EmbeddedWriterView> AddWriter(WriterDTO writerDto)
        {
            var writer = _mapper.Map<Writer>(writerDto);
            var result = _writerRepository.Save(writer);
            if (result == null)
            {
                throw new BadRequestException("Something went wrong with this writer");
            }
            await _writerRepository.SaveChangesAsync();

            return _mapper.Map<EmbeddedWriterView>(result);
        }

        public async Task<bool> DeleteWriter(long id)
        {
            if (_writerRepository.DeleteById(id))
            {
                await _writerRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<WriterView> GetWriter(long id)
        {
            var writer = await _writerRepository.FindByIdAsync(id);
            if (writer == null)
            {
                throw new NotFoundException($"Writer with id {id} not found!");
            }
            return _mapper.Map<WriterView>(writer);
        }

        public async Task<List<EmbeddedPlayView>> GetWritersPlays(long id)
        {
            var plays = await _writerRepository.FindByPlayIdAsync(id);
            return plays
                .Select(p => _mapper.Map<EmbeddedPlayView>(p)).ToList();
        }
    }
}
