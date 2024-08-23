using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideojuegoRanking.Application.Models;
using FluentValidation.Results;


namespace VideojuegoRanking.Application.Interfaces
{
    public interface IRankingService
    {
        Task<ValidationResult> ValidateRankingRequestAsync(RankingRequest request);
        Task<string> GenerateRankingCsv(int top);
        Task<ValidationResult> ValidateTop(int top);
    }
}
