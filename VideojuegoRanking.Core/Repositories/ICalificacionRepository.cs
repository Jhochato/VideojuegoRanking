using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideojuegoRanking.Core.Entities;

namespace VideojuegoRanking.Core.Repositories
{
    public interface ICalificacionRepository
    {
        Task<IEnumerable<Calificacion>> GetByVideojuegoId(int videojuegoId);
        // Otros métodos según sea necesario
    }
}
