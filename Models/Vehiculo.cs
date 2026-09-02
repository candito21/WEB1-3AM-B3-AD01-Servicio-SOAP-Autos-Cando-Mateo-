using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AutosSOAP.Models
{
    [Table("VEHICULO")]
    [DataContract]
    public class Vehiculo
    {
        [Key]
        [DataMember]
        public int IdVehiculo { get; set; }

        [DataMember]
        public string Placa { get; set; } = string.Empty;

        [DataMember]
        public string Marca { get; set; } = string.Empty;

        [DataMember]
        public string Modelo { get; set; } = string.Empty;

        [DataMember]
        public int Anio { get; set; }

        [Column(TypeName = "decimal(10,2)")] // sirve para definir la precisión y escala de la columna en la base de datos
        [DataMember]
        public decimal Precio { get; set; }

        [DataMember]
        public bool Estado { get; set; }

        [DataMember]
        public int IdCategoria { get; set; }

        [IgnoreDataMember]
        public Categoria? Categoria { get; set; }
    }
}
