using System;
using System.Collections.Generic;
using System.Text;

namespace BankKata
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}