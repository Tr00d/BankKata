using System;

namespace BankKata
{
    public interface ITimeProvider
    {
        DateTime UtcNow { get; }
    }
}