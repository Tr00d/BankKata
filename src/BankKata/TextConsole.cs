using System;

namespace BankKata
{
    public class TextConsole : ITextConsole
    {
        public void WriteLine(string text) => Console.WriteLine(text);
    }
}