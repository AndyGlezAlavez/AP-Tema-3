using MaintenanceModel.DataAccess.Context;
using MaintenanceModel.Domain.Entities;
using MaintenanceModel.Domain.Types;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceModel.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext appContext = new ApplicationContext("Data Source = ProgramdB.sqlite");
            if (!appContext.Database.CanConnect())
            {
                appContext.Database.Migrate();
            }



            Guid id2 = Guid.NewGuid();
            Unit unit1 = new Unit(id2, "Unidad especializada", "Ab123S", "Made in china", DateTime.Now);
            appContext.Units.Add(unit1);
            appContext.SaveChanges();

            Guid id3 = Guid.NewGuid();
            Maintenance maintenance1 = new Maintenance(
                id3, MaintenanceTypes.Corrective, "Mantenimiento de prueba", DateTime.Now, unit1);
            appContext.Maintenances.Add(maintenance1);
            appContext.SaveChanges();

            Guid id1 = Guid.NewGuid();
            Worker worker1 = new Worker(id1, "01234567891", "Pepe",maintenance1);

            appContext.Workers.Add(worker1);
            appContext.SaveChanges();


            Unit? unitFormeMaintenance = appContext.Set<Unit>()
                .FirstOrDefault(u => u.Id == maintenance1.UnitId);
            Maintenance? maintenancaFromWorker = appContext.Set<Maintenance>()
                .FirstOrDefault(u => u.Id == worker1.MaintenanceId);

            Console.WriteLine($"a la unidad {unitFormeMaintenance.Name}"
                + $" se le realiza el mantenimiento por esta razon {maintenancaFromWorker.Description}"
                + $" y en el esta trabajando {worker1.Name}");


            //Worker? WorkerFromAuditE = appContext.Set<Worker>().FirstOrDefault(v => v.Id == Auditoria1.WorkerId);
            //Alarm? Alarma2 = appContext.Set<Alarm>().FirstOrDefault();
            //CalderaTemp.Code = "0021";
            //appContext.Variables.Update(CalderaTemp);
            //Variable? CalderaTemp1 = appContext.Set<Variable>().FirstOrDefault(m => m.Id == CalderaTemp.Id);
            //Console.WriteLine($"Codigo de la variable {CalderaTemp1.Code} ");
            //appContext.SaveChanges();
        }
    }
}
