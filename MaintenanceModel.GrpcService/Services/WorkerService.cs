using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MaintenanceModel.Application.Workers.Commands.CreateWorker;
using MaintenanceModel.Application.Workers.Commands.DeleteWorker;
using MaintenanceModel.Application.Workers.Commands.UpdateWorker;
using MaintenanceModel.Application.Workers.Queries.GetAllWorker;
using MaintenanceModel.Application.Workers.Queries.GetWorkerById;
using MaintenanceModel.GrpcProtos;
using MaintenanceModel.GrpcProtos.Worker;
using MediatR;

namespace MaintenanceModel.GrpcService.Services
{
    public class WorkerService : Worker.WorkerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WorkerService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<WorkerDTO> CreateWorker(CreateWorkerRequest request, ServerCallContext context)
        {
            var command = new CreateWorkerCommand(
                request.Ci,
                request.Name,
                _mapper.Map<MaintenanceModel.Domain.Entities.Maintenance>(request.Maintenance));

            var result = _mediator.Send(command).Result;
            return Task.FromResult(_mapper.Map<WorkerDTO>(result));
        }
        public override Task<Empty> DeleteWorker(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteWorkerCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Workers> GetAllWorker(Empty request, ServerCallContext context)
        {
            var query = new GetAllWorkerQuery();

            var result = _mediator.Send(query).Result;

            var workersDTOs = new Workers();

            workersDTOs.Items.AddRange(result.Select(m => _mapper.Map<WorkerDTO>(request)));

            return Task.FromResult(workersDTOs);
        }
        public override Task<NullableWorkerDTO> GetWorker(GetRequest request, ServerCallContext context)
        {
            var query = new GetWorkerByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result == null)
                return Task.FromResult(new NullableWorkerDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableWorkerDTO() { Worker = _mapper.Map<WorkerDTO>(result) });
        }
        public override Task<Empty> UpdateWorker(WorkerDTO request, ServerCallContext context)
        {
            var command = new UpdateWorkerCommand(_mapper.Map<MaintenanceModel.Domain.Entities.Worker>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}
