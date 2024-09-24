using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Maintenances;
using MaintenanceModel.Contracts.Workers;
using MaintenanceModel.DataAccess.Context;
using MaintenanceModel.DataAccess.Repositories;
using MaintenanceModel.DataAccess.Repositories.Maintenances;
using MaintenanceModel.DataAccess.Repositories.Workers;
using MaintenanceModel.DataAccess.Test.Utilities;
using MaintenanceModel.Domain.Entities;
using System.Data;

namespace MaintenanceModel.DataAccess.Test
{
    [TestClass]
    public class WorkerTest
    {
        private IUnitOfWork _unitOfWork;
        private IWorkerRepository _workerrepository;
        private IMaintenanceRepository _maintenaceRepository;

        public WorkerTest()
        {
            ApplicationContext context =
              new ApplicationContext(ConnectionStringProvider
             .GetConnectionString());

            _unitOfWork = new UnitOfWork(context);
            _workerrepository = new WorkerRepository(context);
            _maintenaceRepository = new MaintenanceRepository(context);
            
        }

        [DataRow(0,"9876543210","Ramon")]
        [DataRow(0, "12345678910", "Pepe")]
        [TestMethod]
        public void Can_Add_Worker(int maintenancePosition, string ci, string name)
        {
            //Arrange
            Maintenance? maintenance = _maintenaceRepository.GetAllMaintenance().ElementAtOrDefault(maintenancePosition);
            Assert.IsNotNull(maintenance);
            Guid id = Guid.NewGuid();
            Worker worker = new Worker(id, ci, name,maintenance);

            //Execute
            _workerrepository.AddWorker(worker);
            _unitOfWork.SaveChanges();

            //Assert
            Worker? loadedWorker = _workerrepository.GetWorkerById(id);
            Assert.IsNotNull(loadedWorker);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Worker_By_Id(int position)
        {
            //Arrange
            var worker = _workerrepository.GetAllWorkers().ToList();
            Assert.IsNotNull(worker);
            Assert.IsTrue(position < worker.Count);
            Worker workerToGet = worker[position];

            //Execute
            Worker? loadedWorker = _workerrepository.GetWorkerById(workerToGet.Id);

            //Asert
            Assert.IsNotNull(loadedWorker);
        }

        [TestMethod]
        public void Cannot_Get_Worker_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Worker? loadedWorker = _workerrepository.GetWorkerById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedWorker);

        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Worker(int position)
        {
            //Arrange
            var Workers = _workerrepository.GetAllWorkers();
            Assert.IsNotNull(Workers);
            var count = Workers.Count();
            var workers = Workers.ElementAt(position);
            Assert.IsNotNull(workers);

            //Execute
            _workerrepository.DeleteWorker(workers);
            _unitOfWork.SaveChanges();

            //Assert
            Workers = _workerrepository.GetAllWorkers();
            Assert.AreEqual(count-1,Workers.Count());
            var DeleteWorker = _workerrepository.GetWorkerById(workers.Id);
            Assert.IsNull(DeleteWorker);
        }
        [DataRow(0,"Surge")]
        [TestMethod]
        public void Can_Update_Worker(int position, string nanme)
        {
            //Arrange
            var Workers = _workerrepository.GetAllWorkers();
            Assert.IsNotNull(Workers);
            var worker= Workers.ElementAt(position);
            Assert.IsNotNull(worker);

            //Execute
            worker.Name = nanme;
            _workerrepository.UpdateWorker(worker);
            _unitOfWork.SaveChanges();

            //Assert
            var updateWorker = _workerrepository.GetWorkerById(worker.Id);
            Assert.IsNotNull(updateWorker);
            Assert.AreEqual(worker.Name, updateWorker.Name);

        }
    }
}
