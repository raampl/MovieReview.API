using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieReview.API.Domain.Models;
using MovieReview.API.Resources;

namespace MovieReview.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Movie, MovieResource>()
                .AfterMap((src, dest) =>
                {
                    dest.AverageRating = (float)Math.Round(src.AverageRating * 2, MidpointRounding.AwayFromZero) / 2;
                }
                );

            //CreateMap<Movie, MovieResource>()
            //       .AfterMap((src, dest) =>
            //       {
            //           dest.Genre = src.Genre.ToString();
            //       }
            //    );
            //.ForMember(src => src.Genre, opt => opt.MapFrom(src => (EGenre)src.Genre));
        }
    }

}
