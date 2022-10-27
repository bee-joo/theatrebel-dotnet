using AutoMapper;
using theatrebel.Data.DTOs;
using theatrebel.Data.Models;
using theatrebel.Data.Views;
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

        public async Task<EmbeddedWriterView?> AddWriter(WriterDTO writerDto)
        {
            var writer = _mapper.Map<Writer>(writerDto);
            var result = _writerRepository.Save(writer);
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

        public async Task<WriterView?> GetWriter(long id)
        {
            var writer = await _writerRepository.FindByIdAsync(id);
            return _mapper.Map<WriterView>(writer);
        }

        public Task<List<EmbeddedPlayView>> GetWritersPlays(long id)
        {
            throw new NotImplementedException();
        }
    }
}
