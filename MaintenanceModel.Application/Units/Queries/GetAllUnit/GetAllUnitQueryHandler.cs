using MaintenanceModel.Application.Abstract;
using MaintenanceModel.Contracts.Units;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.Application.Units.Queries.GetAllUnit
{
    public class GetAllUnitQueryHandler : IQueryHandler<GetAllUnitQuery, IEnumerable<Unit>>
    {
        private readonly IUnitRepository _unitRepository;

        public GetAllUnitQueryHandler(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public Task<IEnumerable<Unit>> Handle(GetAllUnitQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_unitRepository.GetAllUnit());
        }
    }
}
