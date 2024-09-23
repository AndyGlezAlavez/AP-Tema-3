using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts.Units;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Units.Queries.GetUnitById
{
    public class GetUnitQueryByIdHandler : IQueryHandler<GetUnitByIdQuery, Unit?>
    {
        private readonly IUnitRepository _unitRepository;

        public GetUnitQueryByIdHandler ( IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public Task<Unit?> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_unitRepository.GetUnitById(request.id));
        }
    }
}
