using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideojuegoRanking.Core.Entities
{
    public class Videojuego
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Compania { get; set; }
        public int AñoLanzamiento { get; set; }
        public decimal Precio { get; set; }
        public double PuntajePromedio { get; set; }
        public ICollection<Calificacion> Calificaciones { get; set; }
    }
}
