using VideojuegoRanking.Application.Interfaces;
using VideojuegoRanking.Application.Services;
using VideojuegoRanking.Core.Repositories;
using Moq;
using FluentValidation;
using VideojuegoRanking.Application.Models;


namespace VideojuegoRanking.Tests;

public class RankingServiceTests
{
    private readonly Mock<IValidator<RankingRequest>> _mockValidator;
    private readonly Mock<IVideojuegoRepository> _mockVideojuegoRepository;
    private readonly Mock<ICalificacionRepository> _mockCalificacionRepository;
    private readonly RankingService _rankingService;

    public RankingServiceTests()
    {
        _mockValidator = new Mock<IValidator<RankingRequest>>();
        _mockVideojuegoRepository = new Mock<IVideojuegoRepository>();
        _mockCalificacionRepository = new Mock<ICalificacionRepository>();
        _rankingService = new RankingService(_mockValidator.Object, _mockVideojuegoRepository.Object, _mockCalificacionRepository.Object);

    }

    [Fact]
    public async Task ValidateTop_ShouldReturnError_WhenTopIsZeroOrNegative()
    {
        var result = await _rankingService.ValidateTop(0);
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.ErrorMessage == "El valor de top debe ser mayor a cero.");
    }

    [Fact]
    public async Task GenerateRankingCsv_ShouldGenerateCorrectCsv()
    {
        // Arrange
        var top = 5;
        var csv = await _rankingService.GenerateRankingCsv(top);

        // Assert
        Assert.Contains("Nombre|Compania|Puntaje|Clasificacion", csv);
    }
}