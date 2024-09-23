using AutoMapper;

namespace MaintenanceModel.GrpcService.Mappers
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile() 
        {
            CreateMap<MaintenanceModel.Domain.Entities.Worker,
                MaintenanceModel.GrpcProtos.Worker.WorkerDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Ci, o => o.MapFrom(s => s.CI))
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Maintenance, o => o.MapFrom(s => s.Maintenance));

            CreateMap<MaintenanceModel.GrpcProtos.Worker.WorkerDTO,
                MaintenanceModel.Domain.Entities.Worker>()
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t=>t.CI, o=>o.MapFrom(s=>s.Ci))
                .ForMember(t=>t.Name,o=>o.MapFrom(s=>s.Name))
                .ForMember(t=>t.Maintenance,o=>o.MapFrom(s=>s.Maintenance));
                
        }
    }
}
