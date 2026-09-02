using AutosSOAP.Models;
using CoreWCF;

namespace AutosSOAP.Services
{
    [ServiceContract]
    public interface IAutoService
    {
        [OperationContract]
        List<Categoria> ObtenerCategorias();

        [OperationContract]
        List<Vehiculo> ObtenerVehiculos();

        [OperationContract]
        Vehiculo? ObtenerVehiculo(int id);

        [OperationContract]
        Vehiculo? AgregarVehiculo(Vehiculo vehiculo);

        [OperationContract]
        Vehiculo? ActualizarVehiculo(Vehiculo vehiculo);

        [OperationContract]
        bool EliminarVehiculo(int id);

        [OperationContract]
        List<Vehiculo> ObtenerVehiculosPorMarca(string marca);

        [OperationContract]
        List<Vehiculo> ObtenerVehiculosPorCategoria(int idCategoria);
    }

}