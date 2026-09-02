using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AutosSOAP.Models
{
    [Table("TBL_CATEGORIAS")]
    [DataContract]
    public class Categoria
    {
        [Key]
        [DataMember]
        public int IdCategoria { get; set; }

        [DataMember]
        public string Nombre { get; set; } = string.Empty;

        [DataMember]
        public string? Descripcion { get; set; }

        [DataMember]
        public bool Estado { get; set; }

        [IgnoreDataMember]
        public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}
