using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MaintenanceModel.Application.Units.Commands.CreateUnit;
using MaintenanceModel.Application.Units.Commands.DeleteUnit;
using MaintenanceModel.Application.Units.Commands.UpdateUnit;
using MaintenanceModel.Application.Units.Queries.GetAllUnit;
using MaintenanceModel.Application.Units.Queries.GetUnitById;
using MaintenanceModel.GrpcProtos;
using MaintenanceModel.GrpcProtos.Unit;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MaintenanceModel.GrpcService.Services
{
    public class UnitService : Unitp.UnitpBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UnitService (IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public override Task<UnitDTO> CreateUnit(CreateUnitRequest request, ServerCallContext context)
        {
            var command = new CreateUnitCommand(
            request.Name,
            request.Code,
            request.Manufacture,
            request.Startdate.ToDateTime());

            var result = _mediator.Send(command).Result;
            result.StartDate = DateTime.SpecifyKind(result.StartDate, DateTimeKind.Local).ToUniversalTime();
            return Task.FromResult(_mapper.Map<UnitDTO>(result));
        }
        public override Task<Empty> DeleteUnit(DeleteRequest request, ServerCallContext context)
        {
             var command = new DeleteUnitCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Units> GetAllUnit(Empty request, ServerCallContext context)
        {

            var query = new GetAllUnitQuery();

            var result = _mediator.Send(query).Result;

            var UnitDTOs = new Units();

            UnitDTOs.Items.AddRange(result.Select(m => _mapper.Map<UnitDTO>(request)));

            return Task.FromResult(UnitDTOs);
        }

        public override Task<Empty> UpdateUnit(UnitDTO request, ServerCallContext context)
        {
            var command = new UpdateUnitCommand(_mapper.Map<Domain.Entities.Unit>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<NullableUnitDTO> GetUnit(GetRequest request, ServerCallContext context)
        {
            var query = new GetUnitByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;
            result.StartDate = DateTime.SpecifyKind(result.StartDate, DateTimeKind.Local).ToUniversalTime();


            if (result == null)
                return Task.FromResult(new NullableUnitDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableUnitDTO() { Unit = _mapper.Map<UnitDTO>(result) });
        }
    }
}
