using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Units;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Units.Commands.CreateUnit
{
    public class CreateUnitCommandHandler : ICommandHandler<CreateUnitCommand, Unit>
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUnitCommandHandler(IUnitRepository unitRepository, IUnitOfWork unitOfWork)
        {
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            Unit resutl = new Unit(
                Guid.NewGuid(),
                request.Name,
                request.Code,
                request.Manufacture,
                request.StartDate);
            _unitRepository.Addunit(resutl);
            _unitOfWork.SaveChanges();
            return Task.FromResult(resutl);

        }
    }
}
