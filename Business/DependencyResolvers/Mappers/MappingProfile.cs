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
using Entities.DTOs.FeatureDtos;
using Entities.DTOs.FeatureDetailDtos;

namespace Business.DependencyResolvers.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // About mappings
            CreateMap<About, GetAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();


            // Booking mappings
            CreateMap<Booking, GetBookingDto>().ReverseMap();
            CreateMap<Booking, GetByIdBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();

            // Category mappings

            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryWithProductsDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            // Contact mappings

            CreateMap<Contact, GetContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();

            // Discount mappings
            CreateMap<Discount, GetDiscountDto>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();

            //Feature mappings
            CreateMap<Feature, GetFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

            //FeatureDetail mappings
            CreateMap<FeatureDetail,GetFeatureDetailDto>().ReverseMap();
            CreateMap<FeatureDetail, GetByIdFeatureDetailDto>().ReverseMap();
            CreateMap<FeatureDetail,CreateFeatureDetailDto>().ReverseMap();
            CreateMap<FeatureDetail,UpdateFeatureDetailDto>().ReverseMap();

            // Product mappings
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithcategoryDto>().ReverseMap();

            // SocialMedia mappings
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetByIdSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();

            // Testimonial mappings
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();

        }
    }
}
