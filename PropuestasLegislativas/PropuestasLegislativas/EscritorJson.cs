using PropuestasLegislativas.Models;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Xml.Linq;

namespace PropuestasLegislativas
{
    public class EscritorJson
    {

        public bool escribir(ModeloPropuestaLegislativa modelo)
        {
            try
            {
                string currentPath = System.IO.Directory.GetCurrentDirectory();
                string jsonData = null;
                List<ModeloPropuestaLegislativa> listaPropuestas;
                try
                {
                    jsonData = File.ReadAllText(currentPath + "\\propuestas.json");
                }
                catch (Exception)
                {
                   
                }

                if (jsonData!=null)
                {
                    listaPropuestas = JsonSerializer.Deserialize<List<ModeloPropuestaLegislativa>>(jsonData);
                }
                else
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
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
           

        }
    }

}
