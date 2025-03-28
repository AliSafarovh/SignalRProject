using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.AboutDtos;
using Entities.DTOs.BookingDtos;
using Entities.DTOs.CategoryDtos;
using Entities.DTOs.ContactDtos;
using Entities.DTOs.DiscountDtos;
using Entities.DTOs.ProductDtos;
using Entities.DTOs.SocialMediaDtos;
using Entities.DTOs.TestimonialDtos;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // About mappings
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<SuccessDataResult<List<About>>, SuccessDataResult<List<GetAboutDto>>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

            // Booking mappings
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();

            // Category mappings
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<SuccessDataResult<List<Category>>, SuccessDataResult<List<GetCategoryDto>>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

            // Contact mappings
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
            CreateMap<SuccessDataResult<List<Contact>>, SuccessDataResult<List<GetContactDto>>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

            // Discount mappings
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountDto>().ReverseMap();
            CreateMap<SuccessDataResult<List<Discount>>, SuccessDataResult<List<GetDiscountDto>>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

            // Product mappings
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<SuccessDataResult<List<Product>>, SuccessDataResult<List<GetProductDto>>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

            // SocialMedia mappings
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
            CreateMap<SuccessDataResult<List<SocialMedia>>, SuccessDataResult<List<GetSocialMediaDto>>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));

            // Testimonial mappings
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
            CreateMap<SuccessDataResult<List<Testimonial>>, SuccessDataResult<List<GetTestimonialDto>>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data));
        }
    }
}
