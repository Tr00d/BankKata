using AutoFixture;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankKata.Test
{
    [TestFixture(Category = "Unit")]
    public class TextConsoleTest
    {
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            this._fixture = new Fixture();
        }

        [Test]
        public void WriteLine_ShouldWriteTextToConsole()
        {
            string text = this._fixture.Create<string>();
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            TextConsole console = new TextConsole();
            console.WriteLine(text);
            Assert.AreEqual($"{text}\r\n", stringWriter.ToString());
        }
    }
}