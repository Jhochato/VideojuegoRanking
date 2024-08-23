using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideojuegoRanking.Core.Entities;
using VideojuegoRanking.Core.Repositories;
using VideojuegoRanking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace VideojuegoRanking.Infrastructure.Repositories
{
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly ApplicationDbContext _context;

        public CalificacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Calificacion>> GetByVideojuegoId(int videojuegoId)
        {
            return await _context.Calificaciones
                .Where(c => c.VideojuegoId == videojuegoId)
                .ToListAsync();
        }
    }
}
