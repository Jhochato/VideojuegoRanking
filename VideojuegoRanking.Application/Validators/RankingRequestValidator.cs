using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using VideojuegoRanking.Application.Models;

namespace VideojuegoRanking.Application.Validators
{
    public class RankingRequestValidator : AbstractValidator<RankingRequest>
    {
        public RankingRequestValidator()
        {
            RuleFor(x => x.Top)
                .GreaterThan(0).WithMessage("El valor del top debe ser mayor que cero.");
        }
    }
}
