using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideojuegoRanking.Core.Entities
{
    public class Calificacion
    {
        public int Id { get; set; }
        public string NicknameJugador { get; set; }
        public int VideojuegoId { get; set; }
        public double Puntuacion { get; set; }
        public Videojuego Videojuego { get; set; }
    }
}
