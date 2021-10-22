using System;
using System.Collections.Generic;
using System.Text;

namespace BankKata
{
    public class TextConsole : ITextConsole
    {
        public void WriteLine(string text) => Console.WriteLine(text);
    }
}