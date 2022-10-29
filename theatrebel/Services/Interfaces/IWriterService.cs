using theatrebel.Data.DTOs;
using theatrebel.Data.Models;
using theatrebel.Data.Views;

namespace theatrebel.Services.Interfaces
{
    public interface IWriterService
    {
        Task<WriterView> GetWriter(long id);
        Task<EmbeddedWriterView> AddWriter(WriterDTO writerDto);
        Task<EmbeddedWriterView> UpdateWriter(long id, WriterUpdateDTO writerDto);
        Task<List<EmbeddedPlayView>> GetWritersPlays(long id);
        Task<bool> DeleteWriter(long id);
    }
}
