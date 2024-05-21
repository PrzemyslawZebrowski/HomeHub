using System.Threading;
using System.Threading.Tasks;
using HomeHub.Domain.Enums.Common;

namespace HomeHub.Application.Abstraction.Services;

public interface ICurrencyService
{
    public Task<decimal> CalculatePrice(decimal price, CurrencyEnum currencyFrom, CurrencyEnum currencyTo, CancellationToken cancellationToken);
}