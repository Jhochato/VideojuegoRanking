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
    public class VideojuegoRepository : IVideojuegoRepository
    {
        private readonly ApplicationDbContext _context;

        public VideojuegoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Videojuego>> GetAllWithRatings()
        {
            //return await _context.Videojuegos
            //    .Include(v => v.Calificaciones)
            //    .Select(v => new
            //    {
            //        v.Id,
            //        v.Nombre,
            //        v.Compania,
            //        v.AñoLanzamiento,
            //        v.Precio,
            //        PuntajePromedio = v.Calificaciones.Any() ? v.Calificaciones.Average(c => c.Puntuacion) : 0,
            //        v.Calificaciones
            //    })
            //    .ToListAsync();

            return await _context.Videojuegos
        .Include(v => v.Calificaciones) // Incluye las calificaciones si es necesario
        .ToListAsync();
        }
    }
}
