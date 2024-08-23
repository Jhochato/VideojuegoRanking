using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideojuegoRanking.Application.Interfaces;
using VideojuegoRanking.Application.Validators;
using VideojuegoRanking.Application.Models;
using VideojuegoRanking.Core.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace VideojuegoRanking.Application.Services
{
    public class RankingService : IRankingService
    {
        private readonly IValidator<RankingRequest> _validator;
        private readonly IVideojuegoRepository _videojuegoRepository;
        private readonly ICalificacionRepository _calificacionRepository;

        public RankingService(IValidator<RankingRequest> validator, IVideojuegoRepository videojuegoRepository, ICalificacionRepository calificacionRepository)
        {
            _validator = validator;
            _videojuegoRepository = videojuegoRepository;
            _calificacionRepository = calificacionRepository;
        }

        public async Task<ValidationResult> ValidateRankingRequestAsync(RankingRequest request)
        {
            return await _validator.ValidateAsync(request); // Devolver Task<ValidationResult>
        }

        public async Task<string> GenerateRankingCsv(int top)
        {
            var rankingRequest = new RankingRequest { Top = top };
            var validationResult = await ValidateRankingRequestAsync(rankingRequest);
            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ArgumentException(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            // Get all videojuegos with their average ratings
            var videojuegos = await _videojuegoRepository.GetAllWithRatings();
            var ranking = videojuegos
                .Select(v => new
                {
                    v.Nombre,
                    v.Compania,
                    Puntaje = v.Calificaciones.Average(c => c.Puntuacion)
                })
                .OrderByDescending(v => v.Puntaje)
                .ToList();

            // Calculate positions and generate CSV
            var csv = new StringBuilder();
            csv.AppendLine("Nombre|Compania|Puntaje|Clasificacion");
            int position = 1;
            foreach (var item in ranking.Take(top <= 0 ? 20 : top))
            {
                var clasificacion = position <= ((top <= 0 ? 20 : top) / 2) ? "GOTY" : "AAA";
                csv.AppendLine($"{item.Nombre}|{item.Compania}|{item.Puntaje}|{clasificacion}");
                position++;
            }

            return csv.ToString();
        }

        public async Task<ValidationResult> ValidateTop(int top)
        {
            var request = new RankingRequest { Top = top };
            return await ValidateRankingRequestAsync(request); // Asegúrate de que este método devuelve Task<ValidationResult>
        }
    }

}
