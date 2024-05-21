using System.Collections.Generic;
using HomeHub.Domain.Common;
using HomeHub.Domain.Enums.Common;

namespace HomeHub.Domain.ValueObjects;

public class Money : ValueObject
{
    public Money(decimal amount, CurrencyEnum currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; private set; }
    public CurrencyEnum Currency { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}