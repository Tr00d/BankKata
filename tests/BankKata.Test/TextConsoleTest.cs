using System;
using System.IO;
using AutoFixture;
using NUnit.Framework;

namespace BankKata.Test
{
    [TestFixture(Category = "Unit")]
    public class TextConsoleTest
    {
        [SetUp]
        public void SetUp()
        {
            this._fixture = new Fixture();
        }

        private Fixture _fixture;

        [Test]
        public void WriteLine_ShouldWriteTextToConsole()
        {
            string text = this._fixture.Create<string>();
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            TextConsole console = new TextConsole();
            console.WriteLine(text);
            Assert.AreEqual($"{text}\n", stringWriter.ToString());
        }
    }
}