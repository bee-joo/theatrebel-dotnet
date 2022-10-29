using AutoMapper;
using theatrebel.Data.DTOs;
using theatrebel.Data.Models;
using theatrebel.Data.Parameters;
using theatrebel.Data.Views;
using theatrebel.Exceptions;
using theatrebel.Repositories.Interfaces;
using theatrebel.Services.Interfaces;

namespace theatrebel.Services
{
    public class PlayService : IPlayService
    {
        private readonly IPlayRepository _playRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IWriterRepository _writerRepository;
        private readonly IMapper _mapper;

        public PlayService(IPlayRepository playRepository, 
                           IReviewRepository reviewRepository, 
                           IWriterRepository writerRepository, 
                           IMapper mapper)
        {
            _playRepository = playRepository;
            _reviewRepository = reviewRepository;
            _writerRepository = writerRepository;
            _mapper = mapper;
        }

        public async Task<PlayView> GetPlay(long id)
        {
            var play = await _playRepository.FindByIdAsync(id);
            if (play == null)
            {
                throw new NotFoundException($"Play with id {id} not found!");
            }
            var playView = _mapper.Map<PlayView>(play);

            return playView;
        }

        public async Task<List<EmbeddedWriterView>?> GetPlaysWriters(long id)
        {
            var writers = await _writerRepository.FindByPlayIdAsync(id);

            return writers
                .Select(w => _mapper.Map<EmbeddedWriterView>(w)).ToList();
        }

        public async Task<List<ReviewView>> GetPlaysReviews(long id)
        {
            var reviews = await _reviewRepository.FindByPlayIdAsync(id);
            return reviews
                .Select(r => _mapper.Map<ReviewView>(r)).ToList();
        }

        public async Task<PlayView> AddPlay(PlayDTO playDto)
        {
            var play = _mapper.Map<Play>(playDto);
            
            if (play.Text != null)
            {
                play.HasText = true;
            }

            var result = _playRepository.Save(play);
            if (result == null)
            {
                throw new BadRequestException("Something went wrong with this play");
            }
            await _playRepository.SaveChangesAsync();

            return _mapper.Map<PlayView>(result);
        }

        public async Task<ReviewView> AddReview(long playId, ReviewDTO reviewDto)
        {
            reviewDto.PlayId ??= playId;

            if (reviewDto.PlayId != playId)
            {
                throw new BadRequestException("Ids of play are not equal");
            }

            var review = _mapper.Map<Review>(reviewDto);
            var result = _reviewRepository.Save(review);
            if (result == null)
            {
                throw new BadRequestException("Something went wrong with this review");
            }
            await _reviewRepository.SaveChangesAsync();

            return _mapper.Map<ReviewView>(result);
        }

        public async Task<bool> DeletePlay(long id)
        {
            if (_playRepository.DeleteById(id))
            {
                await _playRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<EmbeddedPlayView>> SearchPlays(PlayParameters parameters, Pagination pagination)
        {
            var result = await _playRepository.FindByParamsAsync(parameters, pagination);
            return result
                .Select(p => _mapper.Map<EmbeddedPlayView>(p))
                .ToList();
        }
    }
}
