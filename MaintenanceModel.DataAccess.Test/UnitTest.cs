using MaintenanceModel.Contracts;
using MaintenanceModel.Contracts.Units;
using MaintenanceModel.DataAccess.Context;
using MaintenanceModel.DataAccess.Repositories;
using MaintenanceModel.DataAccess.Repositories.Units;
using MaintenanceModel.DataAccess.Test.Utilities;
using MaintenanceModel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceModel.DataAccess.Test
{
    [TestClass]
    public class UnitTest
    {
        private IUnitOfWork _unitOfWork;
        private IUnitRepository _unitRepository;

        public UnitTest()
        {
            ApplicationContext context =
             new ApplicationContext(ConnectionStringProvider
             .GetConnectionString());

            _unitOfWork = new UnitOfWork(context);
            _unitRepository = new UnitRepository(context);
        }

        [DataRow("unidad","1234","made in china")]
        [DataRow("Unidad1","4321","mande in Rusia")]
        [TestMethod]
        public void Can_Add_Unit(string name,string code,string manufacture)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Unit unit = new Unit(id,name,code , manufacture,DateTime.Now);

            //Execute
            _unitRepository.Addunit(unit);
            _unitOfWork.SaveChanges();

            //Assert
            Unit? loadedUnit = _unitRepository.GetUnitById(id);
            Assert.IsNotNull(loadedUnit);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Unit_By_Id(int position)
        {
            //Arrange
            var unit = _unitRepository.GetAllUnit().ToList();
            Assert.IsNotNull(unit);
            Assert.IsTrue(position < unit.Count);
            Unit uniToGet= unit[position];

            //Execute
            Unit? loadedUnit = _unitRepository.GetUnitById(uniToGet.Id);

            //Assert
            Assert.IsNotNull(loadedUnit);

        }
        [TestMethod]
        public void Cannot_Get_Unit_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Unit? loadedUnit= _unitRepository.GetUnitById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedUnit);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Unit(int position)
        {
            //Arrange
            var Units= _unitRepository.GetAllUnit();
            Assert.IsNotNull(Units);
            var count = Units.Count();
            var units= Units.ElementAt(position);
            Assert.IsNotNull(units);

            //Execute
            _unitRepository.Deleteunit(units);
            _unitOfWork.SaveChanges();

            //Assert
            Units = _unitRepository.GetAllUnit();
            Assert.AreEqual(count-1, Units.Count());
            var DeleteUnit = _unitRepository.GetUnitById(units.Id);
            Assert.IsNull(DeleteUnit);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Update_Unit(int position)
        {
            //Arrange
            var Units = _unitRepository.GetAllUnit();
            Assert.IsNotNull(Units);
            var unit= Units.ElementAt(position);
            Assert.IsNotNull(unit);

            //Execute
            unit.Name = "Unidad99";
            _unitRepository.Updateunit(unit);
            _unitOfWork.SaveChanges();

            //Assert
            var updateUnit = _unitRepository.GetUnitById(unit.Id);
            Assert.IsNotNull(updateUnit);
            Assert.AreEqual(updateUnit.Name, unit.Name);
        }

    }
}
