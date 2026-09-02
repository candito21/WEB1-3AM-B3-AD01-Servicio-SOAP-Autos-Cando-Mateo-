using AutosSOAP.Data;
using AutosSOAP.Models;
using CoreWCF;
using Microsoft.EntityFrameworkCore;

namespace AutosSOAP.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, IncludeExceptionDetailInFaults = true)]
    public class AutoService : IAutoService
    {
        private readonly AutosDBContext _autosDBContext;

        public AutoService(AutosDBContext autosDBContext)
        {
            _autosDBContext = autosDBContext;
        }

        public List<Categoria> ObtenerCategorias()
        {
            return _autosDBContext.Categorias
                .AsNoTracking()
                .ToList();
        }

        public List<Vehiculo> ObtenerVehiculos()
        {
            return _autosDBContext.Vehiculos
                .AsNoTracking()
                .ToList();
        }

        public Vehiculo? ObtenerVehiculo(int id)
        {
            return _autosDBContext.Vehiculos
                .AsNoTracking()
                .FirstOrDefault(v => v.IdVehiculo == id);
        }

        public Vehiculo? AgregarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                throw new ArgumentNullException(nameof(vehiculo));
            }

            try
            {
                _autosDBContext.Vehiculos.Add(vehiculo);
                _autosDBContext.SaveChanges();
                return vehiculo;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public Vehiculo? ActualizarVehiculo(Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                return null;
            }

            var vehiculoExistente = _autosDBContext.Vehiculos
                .FirstOrDefault(v => v.IdVehiculo == vehiculo.IdVehiculo);

            if (vehiculoExistente == null)
            {
                return null;
            }

            vehiculoExistente.Placa = vehiculo.Placa;
            vehiculoExistente.Marca = vehiculo.Marca;
            vehiculoExistente.Modelo = vehiculo.Modelo;
            vehiculoExistente.Anio = vehiculo.Anio;
            vehiculoExistente.Precio = vehiculo.Precio;
            vehiculoExistente.Estado = vehiculo.Estado;
            vehiculoExistente.IdCategoria = vehiculo.IdCategoria;

            try
            {
                _autosDBContext.SaveChanges();
                return vehiculoExistente;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public bool EliminarVehiculo(int id)
        {
            var vehiculo = _autosDBContext.Vehiculos
                .FirstOrDefault(v => v.IdVehiculo == id);

            if (vehiculo == null)
            {
                return false;
            }

            try
            {
                _autosDBContext.Vehiculos.Remove(vehiculo);
                _autosDBContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public List<Vehiculo> ObtenerVehiculosPorMarca(string marca)
        {
            return _autosDBContext.Vehiculos
                .AsNoTracking()
                .Where(v => v.Marca.Contains(marca))
                .ToList();
        }

        public List<Vehiculo> ObtenerVehiculosPorCategoria(int idCategoria)
        {
            return _autosDBContext.Vehiculos
                .AsNoTracking()
                .Where(v => v.IdCategoria == idCategoria)
                .ToList();
        }
    }
}
