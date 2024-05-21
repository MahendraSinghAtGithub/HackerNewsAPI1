using AutoMapper;
using HackerNewsAPI.Modal;
using HackerNewsAPI.Modal.DTO;

namespace HackerNewsAPI.AutoMapperProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Story, StoryDTO>()
                .ForMember(dest => dest.URL, opt => opt.MapFrom(src => src.url))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.By))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.descendants))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => formatDateTime(src.time)))
                .ForMember(dest => dest.Title,opt => opt.MapFrom(src=>src.title));
        }

        private string formatDateTime(long unixDate)
        {
            var dotNetDate = DateTimeOffset.FromUnixTimeSeconds(unixDate);
            return dotNetDate.LocalDateTime.ToString("yyyy-MM-ddTHH:mm:ssK");
        }
    }
}
