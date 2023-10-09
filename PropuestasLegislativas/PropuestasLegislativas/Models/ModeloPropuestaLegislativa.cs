namespace PropuestasLegislativas.Models
{
    public class ModeloPropuestaLegislativa
    {
        public Guid? IdPropuesta { get; set; }
        public int? TipoIdentificacion { get; set; }
        public int? Cedula { get; set; }
        public String? Nombre { get; set; }
        public String? Apellidos { get; set; }
        public String? Telefono { get; set; }
        public String? Email { get; set; }
        public int? Provincia { get; set; }
        public int? Canton { get; set; }
        public int? Distrito { get; set; }
        public String? Propuesta { get; set; }

    }
}
