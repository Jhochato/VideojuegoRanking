using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideojuegoRanking.Application.Models
{
    public class RankingResponse
    {
        public string Nombre { get; set; }
        public string Compania { get; set; }
        public double Puntaje { get; set; }
        public string Clasificacion { get; set; }
    }
}
