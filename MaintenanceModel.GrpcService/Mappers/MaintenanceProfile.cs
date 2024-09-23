using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace MaintenanceModel.GrpcService.Mappers
{
    public class MaintenanceProfile : Profile
    {
        public MaintenanceProfile()
        {
            CreateMap<MaintenanceModel.Domain.Entities.Maintenance,
                MaintenanceModel.GrpcProtos.Maintenance.MaintenanceDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Type, o => o.MapFrom(s => (MaintenanceModel.GrpcProtos.MaintenanceTypes)s.Type))
                .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                .ForMember(t => t.Date, o => o.MapFrom(s => Timestamp.FromDateTime(s.Date)));

            CreateMap<MaintenanceModel.GrpcProtos.Maintenance.MaintenanceDTO,
                MaintenanceModel.Domain.Entities.Maintenance>()
                .ForMember(t => t.Type, o => o.MapFrom(s => (MaintenanceModel.Domain.Types.MaintenanceTypes)s.Type))
                .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                .ForMember(t => t.Date, o => o.MapFrom(s => s.Date.ToDateTime()));
        }
    }
}
