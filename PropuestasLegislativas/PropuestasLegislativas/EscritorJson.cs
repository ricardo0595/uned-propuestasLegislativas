using PropuestasLegislativas.Models;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Xml.Linq;

namespace PropuestasLegislativas
{
    public class EscritorJson
    {

        public void escribir(ModeloPropuestaLegislativa modelo)
        {

            string currentPath = System.IO.Directory.GetCurrentDirectory();

            var jsonData = File.ReadAllText(currentPath + "\\propuestas.json");
            List<ModeloPropuestaLegislativa> listaPropuestas = null;
            try
            {
                listaPropuestas = JsonSerializer.Deserialize<List<ModeloPropuestaLegislativa>>(jsonData);

            }
            catch (Exception)
            {
                listaPropuestas = new List<ModeloPropuestaLegislativa>();
            }

            listaPropuestas.Add(new ModeloPropuestaLegislativa()
            {
                IdPropuesta = Guid.NewGuid(),
                Apellidos = modelo.Apellidos,
                Nombre = modelo.Nombre,
                Canton = modelo.Canton,
                Provincia = modelo.Provincia,
                Distrito = modelo.Distrito,
                Cedula = modelo.Cedula,
                Email = modelo.Email,
                Propuesta = modelo.Propuesta,
                Telefono = modelo.Telefono,
                TipoIdentificacion = modelo.TipoIdentificacion
            });
            string json = JsonSerializer.Serialize(listaPropuestas);
            File.WriteAllText(currentPath + "\\propuestas.json", json);

        }
    }

}
