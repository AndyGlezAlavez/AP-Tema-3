using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace MaintenanceModel.GrpcService.Mappers
{
    public class UnitProfile :Profile
    {
        public UnitProfile() 
        {
            CreateMap<MaintenanceModel.Domain.Entities.Unit,
                MaintenanceModel.GrpcProtos.Unit.UnitDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.Manufacture, o => o.MapFrom(s => s.Manufacture))
                .ForMember(t => t.Startdate, o => o.MapFrom(s => Timestamp.FromDateTime(s.StartDate)));

            CreateMap<MaintenanceModel.GrpcProtos.Unit.UnitDTO,
                MaintenanceModel.Domain.Entities.Unit>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.Manufacture, o => o.MapFrom(s => s.Manufacture))
                .ForMember(t => t.StartDate, o => o.MapFrom(s => s.Startdate.ToDateTime()));
        }
    }
}
