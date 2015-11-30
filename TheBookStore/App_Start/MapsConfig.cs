using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.DataTransferObjects;
using TheBookStore.Models;

namespace TheBookStore.App_Start
{
    public static class MapsConfig
    {
        /// <summary>
        /// Maps all Data transfer objects to they respective model classes.
        /// </summary>
        public static void Register()
        {
            Mapper.CreateMap<Book, BookDto>()
                .ForMember(dto => dto.Authors, map => map.MapFrom(entity => entity.Authors));

            Mapper.CreateMap<Author, BookAuthorsDto>()
                .ForMember(dto => dto.FullName, map => map.MapFrom(entity => entity.Fullname))
                .ForSourceMember(entity => entity.Books, map => map.Ignore());

            Mapper.CreateMap<Book, BookAuthorsDto>();

            Mapper.CreateMap<Author, AuthorDto>()
                .ForMember(dto => dto.FullName, map => map.MapFrom(entity => entity.Fullname))
                .ForMember(dto => dto.Books, map => map.MapFrom(entity => entity.Books))
                .ForSourceMember(entity => entity.Books, map => map.Ignore());

            Mapper.CreateMap<Review, ReviewDto>()
                .ForMember(dto => dto.BookId, map => map.MapFrom(entity => entity.Id));
        }

        public static T To<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }

        public static IEnumerable<T> To<T>(this IEnumerable<object> source)
        {
            return Mapper.Map<IEnumerable<T>>(source);
        }
    }
}