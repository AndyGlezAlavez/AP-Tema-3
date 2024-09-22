using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Maintenances;
using MaintenanceModel.Contracts.Units;
using MaintenanceModel.Contracts.Workers;
using MaintenanceModel.DataAccess.Context;
using MaintenanceModel.DataAccess.Repositories;
using MaintenanceModel.DataAccess.Repositories.Maintenances;
using MaintenanceModel.DataAccess.Repositories.Units;
using MaintenanceModel.DataAccess.Test.Utilities;
using MaintenanceModel.Domain.Entities;
using MaintenanceModel.Domain.Types;

namespace MaintenanceModel.DataAccess.Test
{
    [TestClass]
    public class MaintenanceTest
    {
        private IUnitOfWork _unitOfWork;
        private IUnitRepository _unitRepository;
        private IMaintenanceRepository _maintenanceRepository;
        private IWorkerRepository _workerRepository;

        public MaintenanceTest()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider
                .GetConnectionString());

            _unitRepository = new UnitRepository(context);
            _unitOfWork = new UnitOfWork(context);
            _maintenanceRepository = new MaintenanceRepository(context);

        }

        [DataRow(0, "probando")]
        [DataRow(0,"Volviendo a probar")]
        [TestMethod]
        public void Can_Add_Maintenance(int unitPosition, string description)
        {
            //Arrange
            Unit? unit = _unitRepository.GetAllUnit().ElementAtOrDefault(unitPosition);
            Assert.IsNotNull(unit);
            Guid id = Guid.NewGuid();
            Maintenance maintenance = new Maintenance(id, MaintenanceTypes.Preventive, description, DateTime.Now, unit);

            //Execute
            _maintenanceRepository.AddMaintenance(maintenance);
            _unitOfWork.SaveChanges();

            //Assert
            Maintenance? loadedMaintenance = _maintenanceRepository.GetMaintenanceById(id);
            Assert.IsNotNull(loadedMaintenance);

        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Maintenance_By_Id(int position)
        {
            //Arrange
            var maintenance = _maintenanceRepository.GetAllMaintenance().ToList();
            Assert.IsNotNull(maintenance);
            Assert.IsTrue(position < maintenance.Count());
            Maintenance maintenanceToGet = maintenance[position];

            //Execute
            Maintenance? loadedMaintenance = _maintenanceRepository
                .GetMaintenanceById(maintenanceToGet.Id);

            //Assert
            Assert.IsNotNull(loadedMaintenance);

        }

        [TestMethod]
        public void Cannot_Get_Maintenance_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Maintenance? loadedMaintenance= _maintenanceRepository.GetMaintenanceById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedMaintenance);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Maintenance(int position)
        {
            //Arrange
            var Maintenances =_maintenanceRepository.GetAllMaintenance();
            Assert.IsNotNull(Maintenances);
            var count= Maintenances.Count();
            var maintenance =Maintenances.ElementAt(position);
            Assert.IsNotNull(maintenance);
            
            //Execute
            _maintenanceRepository.DeleteMaintenance(maintenance);
            _unitOfWork.SaveChanges();

            //Assert
            Maintenances = _maintenanceRepository.GetAllMaintenance();
            Assert.AreEqual(count-1,Maintenances.Count());
            var DeleteMaintenances = _maintenanceRepository.GetMaintenanceById(maintenance.Id);
            Assert.IsNull(DeleteMaintenances);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Update_Maintenance(int position)
        {
            //Arrange
            var Maintenances = _maintenanceRepository.GetAllMaintenance();
            Assert.IsNotNull(Maintenances);
            var maintenance= Maintenances.ElementAt(position);
            Assert.IsNotNull(maintenance);

            //Execute
            maintenance.Type= MaintenanceTypes.Corrective;
            _maintenanceRepository.UpdateMaintenance(maintenance);
            _unitOfWork.SaveChanges();

            //assert
            var updateMaintenance = _maintenanceRepository.GetMaintenanceById(maintenance.Id);
            Assert.IsNotNull(updateMaintenance);
            Assert.AreEqual(updateMaintenance.Type, maintenance.Type);
        }
    }
}
