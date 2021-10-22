using System;
using System.Collections.Generic;
using System.Text;

namespace BankKata
{
    public interface ITimeProvider
    {
        DateTime UtcNow { get; }
    }
}