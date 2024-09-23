using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MaintenanceModel.Application.Maintenances.Commands.CreateMaintenance;
using MaintenanceModel.Application.Maintenances.Commands.DeleteMaintenance;
using MaintenanceModel.Application.Maintenances.Commands.UpdateMaintenance;
using MaintenanceModel.Application.Maintenances.Queries.GetAllMaintenance;
using MaintenanceModel.Application.Maintenances.Queries.GetMaintenanceById;
using MaintenanceModel.Application.Units.Commands.CreateUnit;
using MaintenanceModel.Application.Units.Commands.UpdateUnit;
using MaintenanceModel.Application.Units.Queries.GetUnitById;
using MaintenanceModel.GrpcProtos;
using MaintenanceModel.GrpcProtos.Maintenance;
using MaintenanceModel.GrpcProtos.Unit;
using MediatR;

namespace MaintenanceModel.GrpcService.Services
{
    public class MainteannceService : Maintenance.MaintenanceBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MainteannceService (IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<MaintenanceDTO> CreateMaintenance(CreateMaintenanceRequest request, ServerCallContext context)
        {
            var command = new CreateMaintenanceCommand(
                _mapper.Map<MaintenanceModel.Domain.Types.MaintenanceTypes>(request.Type),
                request.Description,
                request.Date.ToDateTime(),
                _mapper.Map<MaintenanceModel.Domain.Entities.Unit>(request.Unit));

            var result = _mediator.Send(command).Result;
            result.Date = DateTime.SpecifyKind(result.Date, DateTimeKind.Local).ToUniversalTime();
            return Task.FromResult(_mapper.Map<MaintenanceDTO>(result));
        }
        public override Task<Empty> DeleteMainteannce(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteMaintenanceCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Maintenaces> GetAllMaintenance(Empty request, ServerCallContext context)
        {
            var query = new GetAllMaintenanceQuery();

            var result = _mediator.Send(query).Result;

            var maintenanceDTOs = new Maintenaces();

            maintenanceDTOs.Items.AddRange(result.Select(m => _mapper.Map<MaintenanceDTO>(request)));

            return Task.FromResult(maintenanceDTOs);
        }
        public override Task<NullableMaintenanceDTO> GetMaintenance(GetRequest request, ServerCallContext context)
        {
            var query = new GetMaintenanceByIDQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result == null)
                return Task.FromResult(new NullableMaintenanceDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableMaintenanceDTO() { Maintenance = _mapper.Map<MaintenanceDTO>(result) });
        }
        public override Task<Empty> UpdateMaintenance(MaintenanceDTO request, ServerCallContext context)
        {
            var command = new UpdateMaintenanceCommand(_mapper.Map<MaintenanceModel.Domain.Entities.Maintenance>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
       
    }
}
