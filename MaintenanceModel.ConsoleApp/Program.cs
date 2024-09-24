using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using MaintenanceModel.GrpcProtos;
using MaintenanceModel.GrpcProtos.Maintenance;
using MaintenanceModel.GrpcProtos.Unit;
using MaintenanceModel.GrpcProtos.Worker;

namespace MaintenanceModel.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();

            Console.WriteLine("Creating channel and client");
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5071", new GrpcChannelOptions { HttpHandler = httpHandler });

            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            var UnitClient = new Unitp.UnitpClient(channel);
            var MaintenanceClient = new Maintenance.MaintenanceClient(channel);
            var WorkerClient = new Worker.WorkerClient(channel);
           


            Console.WriteLine("Presione una tecla para Crear la unidad");
            Console.ReadKey();
            var createResponse = UnitClient.CreateUnit(new CreateUnitRequest()
            {
                Name = "test",
                Code = "test code",
                Manufacture = "Manufacture test",
                Startdate = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime()),
            }
            );

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create Unit");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }


            //Mantenimiento

            Console.WriteLine("Presione una tecla para Crear el mantenimiento");
            Console.ReadKey();
            var createResponse1 = MaintenanceClient.CreateMaintenance(new CreateMaintenanceRequest()
            {
                Type = MaintenanceTypes.Corrective,
                Description="Test",
                Date= Timestamp.FromDateTime(DateTime.Now.ToUniversalTime()),
                Unit = createResponse,

            }
            );

            if (createResponse1 is null)
            {
                Console.WriteLine("Cannot create Maintenance");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }


            //trabajador
            Console.WriteLine("Presione una tecla para Crear un trabajador");
            Console.ReadKey();
            var createResponse2 = WorkerClient.CreateWorker(new CreateWorkerRequest()
            {
                Ci = "Test",
                Name = "test",
                Maintenance = createResponse1
            }
            );

            if (createResponse2 is null)
            {
                Console.WriteLine("Cannot create Worker");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }



            Console.WriteLine($"Presione una tecla para obtener el modulo con Id {createResponse.Id}");
            Console.ReadKey();
            var getByIdResponse = UnitClient.GetUnit(new GetRequest() { Id = createResponse.Id.ToString() });
            if (getByIdResponse is null)
            {
                Console.WriteLine("Cannot get Module");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de los modulos {getByIdResponse.Unit.Name}");
            }



            Console.WriteLine($"Presione una tecla para obtener el mantenimiento con Id {createResponse1.Id}");
            Console.ReadKey();
            var getByIdResponse1 = MaintenanceClient.GetMaintenance(new GetRequest() { Id = createResponse1.Id.ToString() });
            if (getByIdResponse1 is null)
            {
                Console.WriteLine("Cannot get Module");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa del mantenimiento {getByIdResponse1.Maintenance.Description}");
            }




            Console.WriteLine("Presione una tecla para modificar el modulo");
            Console.ReadKey();
            createResponse.Name= "Update Test";
            UnitClient.UpdateUnit(createResponse);
            var updateResponse = UnitClient.GetUnit(new GetRequest() { Id = createResponse.Id });
            if (updateResponse is not null &&
                 updateResponse.KindCase == NullableUnitDTO.KindOneofCase.Unit &&
                 updateResponse.Unit.Name == createResponse.Name)
            {
                Console.WriteLine($"modificacion exitosa");
            }








            Console.WriteLine("Presione una tecla para eliminar el modulo");
            Console.ReadKey();

            UnitClient.DeleteUnit(new DeleteRequest() { Id = createResponse.Id });
            var deleteGetResponse = UnitClient.GetUnit((new GetRequest() { Id = createResponse.Id }));
            if (deleteGetResponse is null || deleteGetResponse.KindCase != NullableUnitDTO.KindOneofCase.Unit)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }



            channel.Dispose();
        }
    }
}
