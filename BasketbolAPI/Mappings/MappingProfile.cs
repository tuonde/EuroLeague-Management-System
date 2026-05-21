using AutoMapper;
using BasketbolAPI.DTOs;
using BasketbolAPI.Models;

namespace BasketbolAPI.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Team, TeamDto>();
        CreateMap<TeamCreateDto, Team>();
        CreateMap<TeamUpdateDto, Team>();

        CreateMap<Player, PlayerDto>()
            .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team!.Name));
        CreateMap<PlayerCreateDto, Player>();
        CreateMap<PlayerUpdateDto, Player>();

        CreateMap<Match, MatchDto>()
            .ForMember(dest => dest.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam!.Name))
            .ForMember(dest => dest.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam!.Name));
        CreateMap<MatchCreateDto, Match>();
        CreateMap<MatchUpdateDto, Match>();
    }
}
