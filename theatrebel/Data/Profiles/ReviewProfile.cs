using AutoMapper;
using theatrebel.Data.DTOs;
using theatrebel.Data.Models;
using theatrebel.Data.Views;

namespace theatrebel.Data.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewDTO, Review>();
            CreateMap<Review, ReviewView>();
        }
    }
}
