namespace PropuestasLegislativas.Models
{
    public class ModeloPropuestaLegislativa
    {
        public Guid? IdPropuesta { get; set; }
        public String? TipoIdentificacion { get; set; }
        public String? Cedula { get; set; }
        public String? Nombre { get; set; }
        public String? Apellidos { get; set; }
        public String? Telefono { get; set; }
        public String? Email { get; set; }
        public String? Provincia { get; set; }
        public String? Canton { get; set; }
        public String? Distrito { get; set; }
        public String? Propuesta { get; set; }

    }
}
