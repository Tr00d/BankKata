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
            var text = this._fixture.Create<string>();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var console = new TextConsole();
            console.WriteLine(text);
            Assert.AreEqual($"{text}\r\n", stringWriter.ToString());
        }
    }
}